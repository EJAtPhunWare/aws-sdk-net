/*
 * Copyright 2010-2014 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

/*
 * Do not modify this file. This file is generated from the ecs-2014-11-13.normal.json service model.
 */


using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Amazon.ECS.Model;

namespace Amazon.ECS
{
    /// <summary>
    /// Interface for accessing ECS
    ///
    /// Amazon EC2 Container Service (Amazon ECS) is a highly scalable, fast, container management
    /// service that makes it easy to run, stop, and manage Docker containers on a cluster
    /// of Amazon EC2 instances. Amazon ECS lets you launch and stop container-enabled applications
    /// with simple API calls, allows you to get the state of your cluster from a centralized
    /// service, and gives you access to many familiar Amazon EC2 features like security groups,
    /// Amazon EBS volumes, and IAM roles.
    /// 
    ///  
    /// <para>
    /// You can use Amazon ECS to schedule the placement of containers across your cluster
    /// based on your resource needs, isolation policies, and availability requirements. Amazon
    /// EC2 Container Service eliminates the need for you to operate your own cluster management
    /// and configuration management systems or worry about scaling your management infrastructure.
    /// </para>
    /// </summary>
    public partial interface IAmazonECS : IDisposable
    {

        
        #region  CreateCluster

        /// <summary>
        /// Creates a new Amazon ECS cluster. By default, your account will receive a <code>default</code>
        /// cluster when you launch your first container instance. However, you can create your
        /// own cluster with a unique name with the <code>CreateCluster</code> action.
        /// 
        ///  <important> 
        /// <para>
        /// During the preview, each account is limited to two clusters.
        /// </para>
        ///  </important>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the CreateCluster service method.</param>
        /// 
        /// <returns>The response from the CreateCluster service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        CreateClusterResponse CreateCluster(CreateClusterRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the CreateCluster operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the CreateCluster operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<CreateClusterResponse> CreateClusterAsync(CreateClusterRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  DeleteCluster

        /// <summary>
        /// Deletes the specified cluster. You must deregister all container instances from this
        /// cluster before you may delete it. You can list the container instances in a cluster
        /// with <a>ListContainerInstances</a> and deregister them with <a>DeregisterContainerInstance</a>.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DeleteCluster service method.</param>
        /// 
        /// <returns>The response from the DeleteCluster service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        DeleteClusterResponse DeleteCluster(DeleteClusterRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the DeleteCluster operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the DeleteCluster operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<DeleteClusterResponse> DeleteClusterAsync(DeleteClusterRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  DeregisterContainerInstance

        /// <summary>
        /// Deregisters an Amazon ECS container instance from the specified cluster. This instance
        /// will no longer be available to run tasks.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DeregisterContainerInstance service method.</param>
        /// 
        /// <returns>The response from the DeregisterContainerInstance service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        DeregisterContainerInstanceResponse DeregisterContainerInstance(DeregisterContainerInstanceRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the DeregisterContainerInstance operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the DeregisterContainerInstance operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<DeregisterContainerInstanceResponse> DeregisterContainerInstanceAsync(DeregisterContainerInstanceRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  DeregisterTaskDefinition

        /// <summary>
        /// Deregisters the specified task definition. You will no longer be able to run tasks
        /// from this definition after deregistration.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DeregisterTaskDefinition service method.</param>
        /// 
        /// <returns>The response from the DeregisterTaskDefinition service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        DeregisterTaskDefinitionResponse DeregisterTaskDefinition(DeregisterTaskDefinitionRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the DeregisterTaskDefinition operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the DeregisterTaskDefinition operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<DeregisterTaskDefinitionResponse> DeregisterTaskDefinitionAsync(DeregisterTaskDefinitionRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  DescribeClusters

        /// <summary>
        /// Describes one or more of your clusters.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DescribeClusters service method.</param>
        /// 
        /// <returns>The response from the DescribeClusters service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        DescribeClustersResponse DescribeClusters(DescribeClustersRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the DescribeClusters operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the DescribeClusters operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<DescribeClustersResponse> DescribeClustersAsync(DescribeClustersRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  DescribeContainerInstances

        /// <summary>
        /// Describes Amazon EC2 Container Service container instances. Returns metadata about
        /// registered and remaining resources on each container instance requested.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DescribeContainerInstances service method.</param>
        /// 
        /// <returns>The response from the DescribeContainerInstances service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        DescribeContainerInstancesResponse DescribeContainerInstances(DescribeContainerInstancesRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the DescribeContainerInstances operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the DescribeContainerInstances operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<DescribeContainerInstancesResponse> DescribeContainerInstancesAsync(DescribeContainerInstancesRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  DescribeTaskDefinition

        /// <summary>
        /// Describes a task definition.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DescribeTaskDefinition service method.</param>
        /// 
        /// <returns>The response from the DescribeTaskDefinition service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        DescribeTaskDefinitionResponse DescribeTaskDefinition(DescribeTaskDefinitionRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the DescribeTaskDefinition operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the DescribeTaskDefinition operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<DescribeTaskDefinitionResponse> DescribeTaskDefinitionAsync(DescribeTaskDefinitionRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  DescribeTasks

        /// <summary>
        /// Describes a specified task or tasks.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DescribeTasks service method.</param>
        /// 
        /// <returns>The response from the DescribeTasks service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        DescribeTasksResponse DescribeTasks(DescribeTasksRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the DescribeTasks operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the DescribeTasks operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<DescribeTasksResponse> DescribeTasksAsync(DescribeTasksRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  ListClusters

        /// <summary>
        /// Returns a list of existing clusters.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the ListClusters service method.</param>
        /// 
        /// <returns>The response from the ListClusters service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        ListClustersResponse ListClusters(ListClustersRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the ListClusters operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the ListClusters operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<ListClustersResponse> ListClustersAsync(ListClustersRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  ListContainerInstances

        /// <summary>
        /// Returns a list of container instances in a specified cluster.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the ListContainerInstances service method.</param>
        /// 
        /// <returns>The response from the ListContainerInstances service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        ListContainerInstancesResponse ListContainerInstances(ListContainerInstancesRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the ListContainerInstances operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the ListContainerInstances operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<ListContainerInstancesResponse> ListContainerInstancesAsync(ListContainerInstancesRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  ListTaskDefinitions

        /// <summary>
        /// Returns a list of task definitions that are registered to your account. You can filter
        /// the results by family name with the <code>familyPrefix</code> parameter.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the ListTaskDefinitions service method.</param>
        /// 
        /// <returns>The response from the ListTaskDefinitions service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        ListTaskDefinitionsResponse ListTaskDefinitions(ListTaskDefinitionsRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the ListTaskDefinitions operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the ListTaskDefinitions operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<ListTaskDefinitionsResponse> ListTaskDefinitionsAsync(ListTaskDefinitionsRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  ListTasks

        /// <summary>
        /// Returns a list of tasks for a specified cluster. You can filter the results by family
        /// name or by a particular container instance with the <code>family</code> and <code>containerInstance</code>
        /// parameters.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the ListTasks service method.</param>
        /// 
        /// <returns>The response from the ListTasks service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        ListTasksResponse ListTasks(ListTasksRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the ListTasks operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the ListTasks operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<ListTasksResponse> ListTasksAsync(ListTasksRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  RegisterTaskDefinition

        /// <summary>
        /// Registers a new task definition from the supplied <code>family</code> and <code>containerDefinitions</code>.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the RegisterTaskDefinition service method.</param>
        /// 
        /// <returns>The response from the RegisterTaskDefinition service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        RegisterTaskDefinitionResponse RegisterTaskDefinition(RegisterTaskDefinitionRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the RegisterTaskDefinition operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the RegisterTaskDefinition operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<RegisterTaskDefinitionResponse> RegisterTaskDefinitionAsync(RegisterTaskDefinitionRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  RunTask

        /// <summary>
        /// Start a task using random placement and the default Amazon ECS scheduler. If you want
        /// to use your own scheduler or place a task on a specific container instance, use <code>StartTask</code>
        /// instead.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the RunTask service method.</param>
        /// 
        /// <returns>The response from the RunTask service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        RunTaskResponse RunTask(RunTaskRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the RunTask operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the RunTask operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<RunTaskResponse> RunTaskAsync(RunTaskRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  StartTask

        /// <summary>
        /// Starts a new task from the specified task definition on the specified container instance
        /// or instances. If you want to use the default Amazon ECS scheduler to place your task,
        /// use <code>RunTask</code> instead.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the StartTask service method.</param>
        /// 
        /// <returns>The response from the StartTask service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        StartTaskResponse StartTask(StartTaskRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the StartTask operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the StartTask operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<StartTaskResponse> StartTaskAsync(StartTaskRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
        #region  StopTask

        /// <summary>
        /// Stops a running task.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the StopTask service method.</param>
        /// 
        /// <returns>The response from the StopTask service method, as returned by ECS.</returns>
        /// <exception cref="Amazon.ECS.Model.ClientException">
        /// These errors are usually caused by something the client did, such as use an action
        /// or resource on behalf of a user that doesn't have permission to use the action or
        /// resource, or specify an identifier that is not valid.
        /// </exception>
        /// <exception cref="Amazon.ECS.Model.ServerException">
        /// These errors are usually caused by a server-side issue.
        /// </exception>
        StopTaskResponse StopTask(StopTaskRequest request);

        /// <summary>
        /// Initiates the asynchronous execution of the StopTask operation.
        /// </summary>
        /// 
        /// <param name="request">Container for the necessary parameters to execute the StopTask operation.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<StopTaskResponse> StopTaskAsync(StopTaskRequest request, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
    }
}