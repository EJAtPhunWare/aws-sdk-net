﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AWSSDK_DotNet.IntegrationTests.Utils;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;


namespace AWSSDK_DotNet.IntegrationTests.Tests.DynamoDB
{
    [TestClass]
    public partial class DynamoDBTests : TestBase<AmazonDynamoDBClient>
    {
        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (!ReuseTables)
                RemoveCreatedTables();

            BaseClean();
            if (Context != null)
                Context.Dispose();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            CreateTestTables();

            // Since tables have a variable prefix, configure the prefix for the process
            AWSConfigs.DynamoDBConfig.Context.TableNamePrefix = TableNamePrefix;

            // Construct single context object to use for all operations
            CreateContext(DynamoDBEntryConversion.V1);
        }

        [TestCleanup]
        public void CleanupTables()
        {
            ClearTable(hashTableName);
            ClearTable(hashRangeTableName);
        }

        public static void CreateContext(DynamoDBEntryConversion conversion)
        {
            var config = new DynamoDBContextConfig
            {
                //IgnoreNullValues = true
                Conversion = conversion
            };
            Context = new DynamoDBContext(Client, config);
        }

        public static string hashTableName;
        public static string hashRangeTableName;
        public static DynamoDBContext Context = null;

        public static int OneMB = 1024 * 1024;
        public static int MaxItemSize = 65 * 1024;
        public static int MaxBatchSize = 25;

        /// <summary>
        /// Setting this value to true will configure the tests to not
        /// delete the tables after the test has finished.
        /// </summary>
        public const bool ReuseTables = true;
        public const int DefaultReadCapacity = 50;
        public const int DefaultWriteCapacity = 50;

        public const int ScanLimit = 1;
        public static readonly string BaseTableNamePrefix = "DotNetTests";
        public static readonly string TableNamePrefix = BaseTableNamePrefix + "-" +
            (ReuseTables ? string.Empty : + DateTime.Now.ToFileTime() + "-");
        public static List<string> CreatedTables = new List<string>();

        public static void ClearTable(string tableName)
        {
            var table = Table.LoadTable(Client, tableName, DynamoDBEntryConversion.V1);
            var keyNames = table.Keys.Keys.ToList();
            
            // Retrieve all keys
            var keys = table.Scan(new ScanOperationConfig
            {
                AttributesToGet = keyNames,
                Select = SelectValues.SpecificAttributes
            }).GetRemaining();

            // Populate BatchWrite to delete all keys
            var batchWrite = table.CreateBatchWrite();
            foreach (var key in keys)
                batchWrite.AddKeyToDelete(key);

            // Execute batch write
            batchWrite.Execute();
        }

        public static void CreateTestTables()
        {
            hashTableName = TableNamePrefix + "HashTable";
            hashRangeTableName = TableNamePrefix + "HashRangeTable";
            bool createHashTable = true;
            bool createHashRangeTable = true;

            if (ReuseTables)
            {
                if (GetStatus(hashTableName) != null)
                {
                    WaitForTableStatus(hashTableName, TableStatus.ACTIVE);
                    createHashTable = false;
                }
                if (GetStatus(hashRangeTableName) != null)
                {
                    WaitForTableStatus(hashRangeTableName, TableStatus.ACTIVE);
                    createHashRangeTable = false;
                }
            }

            if (createHashTable)
            {
                // Create hash-key table with global index
                Client.CreateTable(new CreateTableRequest
                {
                    TableName = hashTableName,
                    AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition { AttributeName = "Id", AttributeType = ScalarAttributeType.N },
                    new AttributeDefinition { AttributeName = "Company", AttributeType = ScalarAttributeType.S },
                    new AttributeDefinition { AttributeName = "Price", AttributeType = ScalarAttributeType.N }
                },
                    KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement { KeyType = KeyType.HASH, AttributeName = "Id" }
                },
                    GlobalSecondaryIndexes = new List<GlobalSecondaryIndex>
                {
                    new GlobalSecondaryIndex
                    {
                        IndexName = "GlobalIndex",
                        KeySchema = new List<KeySchemaElement>
                        {
                            new KeySchemaElement { AttributeName = "Company", KeyType = KeyType.HASH },
                            new KeySchemaElement { AttributeName = "Price", KeyType = KeyType.RANGE }
                        },
                        ProvisionedThroughput = new ProvisionedThroughput { ReadCapacityUnits = 1, WriteCapacityUnits = 1 },
                        Projection = new Projection { ProjectionType = ProjectionType.ALL }
                    }
                },
                    ProvisionedThroughput = new ProvisionedThroughput { ReadCapacityUnits = DefaultReadCapacity, WriteCapacityUnits = DefaultWriteCapacity },
                });
                CreatedTables.Add(hashTableName);

                // Wait for table to be ready
                WaitForTableStatus(hashTableName, TableStatus.ACTIVE);
            }

            if (createHashRangeTable)
            {
                // Create hash-and-range-key table with local and global indexes
                Client.CreateTable(new CreateTableRequest
                {
                    TableName = hashRangeTableName,
                    AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition { AttributeName = "Name", AttributeType = ScalarAttributeType.S },
                    new AttributeDefinition { AttributeName = "Age", AttributeType = ScalarAttributeType.N },
                    new AttributeDefinition { AttributeName = "Company", AttributeType = ScalarAttributeType.S },
                    new AttributeDefinition { AttributeName = "Score", AttributeType = ScalarAttributeType.N },
                    new AttributeDefinition { AttributeName = "Manager", AttributeType = ScalarAttributeType.S }
                },
                    KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement { AttributeName = "Name", KeyType = KeyType.HASH },
                    new KeySchemaElement { AttributeName = "Age", KeyType = KeyType.RANGE }
                },
                    GlobalSecondaryIndexes = new List<GlobalSecondaryIndex>
                {
                    new GlobalSecondaryIndex
                    {
                        IndexName = "GlobalIndex",
                        KeySchema = new List<KeySchemaElement>
                        {
                            new KeySchemaElement { AttributeName = "Company", KeyType = KeyType.HASH },
                            new KeySchemaElement { AttributeName = "Score", KeyType = KeyType.RANGE }
                        },
                        ProvisionedThroughput = new ProvisionedThroughput { ReadCapacityUnits = 1, WriteCapacityUnits = 1 },
                        Projection = new Projection { ProjectionType = ProjectionType.ALL }
                    }
                },
                    LocalSecondaryIndexes = new List<LocalSecondaryIndex> 
                {
                    new LocalSecondaryIndex
                    {
                        IndexName = "LocalIndex",
                        KeySchema = new List<KeySchemaElement>
                        {
                            new KeySchemaElement { AttributeName = "Name", KeyType = KeyType.HASH },
                            new KeySchemaElement { AttributeName = "Manager", KeyType = KeyType.RANGE }
                        },
                        Projection = new Projection
                        {
                            ProjectionType = ProjectionType.INCLUDE,
                            NonKeyAttributes = new List<string> { "Company", "Score" }
                        }
                    }
                },
                    ProvisionedThroughput = new ProvisionedThroughput { ReadCapacityUnits = DefaultReadCapacity, WriteCapacityUnits = DefaultWriteCapacity },
                });
                CreatedTables.Add(hashRangeTableName);

                // Wait for table to be ready
                WaitForTableStatus(hashRangeTableName, TableStatus.ACTIVE);
            }
        }
        public static void RemoveCreatedTables()
        {
            if (CreatedTables.Count > 0)
            {
                // Wait for all tables to be active first
                WaitForTableStatus(CreatedTables, TableStatus.ACTIVE);

                foreach (var table in CreatedTables)
                {
                    Client.DeleteTable(table);
                }

                // Wait for tables to be deleted
                WaitForTableStatus(CreatedTables, null);

                CreatedTables.Clear();
            }
        }

        public static void WaitForTableStatus(string tableName, TableStatus status)
        {
            WaitForTableStatus(new string[] { tableName }, status);
        }
        public static void WaitForTableStatus(IEnumerable<string> tableNames, TableStatus status)
        {
            Console.WriteLine("Waiting for tables [{0}] to reach status {1}",
                string.Join(", ", tableNames.ToArray()), status);
            var tablesList = new List<string>(tableNames);

            Func<bool> testFunction = () =>
            {
                bool allReady = true;
                foreach(var tableName in tablesList.ToArray())
                {
                    var tableStatus = GetStatus(tableName);
                    allReady &= (tableStatus == status);
                    if (allReady)
                        tablesList.Remove(tableName);

                    if (!allReady)
                        break;
                }

                return allReady;
            };

            UtilityMethods.WaitUntil(testFunction);

            Console.WriteLine("All tables ready");
        }
        public static TableStatus GetStatus(string tableName)
        {
            TableStatus status = null;
            try
            {
                status = Client.DescribeTable(tableName).Table.TableStatus;
            }
            catch(ResourceNotFoundException)
            {
                status = null;
            }

            return status;
        }
    }
}
