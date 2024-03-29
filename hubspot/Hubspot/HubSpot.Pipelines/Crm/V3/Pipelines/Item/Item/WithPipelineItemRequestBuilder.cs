// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using True.Services.HubSpot.Pipelines.Crm.V3.Pipelines.Item.Item.Audit;
using True.Services.HubSpot.Pipelines.Crm.V3.Pipelines.Item.Item.Stages;
using True.Services.HubSpot.Pipelines.Models;
namespace True.Services.HubSpot.Pipelines.Crm.V3.Pipelines.Item.Item {
    /// <summary>
    /// Builds and executes requests for operations under \crm\v3\pipelines\{objectType}\{pipelineId}
    /// </summary>
    public class WithPipelineItemRequestBuilder : BaseRequestBuilder {
        /// <summary>The audit property</summary>
        public AuditRequestBuilder Audit { get =>
            new AuditRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The stages property</summary>
        public StagesRequestBuilder Stages { get =>
            new StagesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new WithPipelineItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithPipelineItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/crm/v3/pipelines/{objectType}/{pipelineId}{?validateReferencesBeforeDelete*,validateDealStageUsagesBeforeDelete*}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new WithPipelineItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithPipelineItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/crm/v3/pipelines/{objectType}/{pipelineId}{?validateReferencesBeforeDelete*,validateDealStageUsagesBeforeDelete*}", rawUrl) {
        }
        /// <summary>
        /// Delete the pipeline identified by `{pipelineId}`.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task DeleteAsync(Action<RequestConfiguration<WithPipelineItemRequestBuilderDeleteQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task DeleteAsync(Action<RequestConfiguration<WithPipelineItemRequestBuilderDeleteQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToDeleteRequestInformation(requestConfiguration);
            await RequestAdapter.SendNoContentAsync(requestInfo, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Return a single pipeline object identified by its unique `{pipelineId}`.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<Pipeline?> GetAsync(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<Pipeline> GetAsync(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<Pipeline>(requestInfo, Pipeline.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Perform a partial update of the pipeline identified by `{pipelineId}`. The updated pipeline will be returned in the response.
        /// </summary>
        /// <param name="body">An input used to update some properties on a pipeline definition.</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<Pipeline?> PatchAsync(PipelinePatchInput body, Action<RequestConfiguration<WithPipelineItemRequestBuilderPatchQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<Pipeline> PatchAsync(PipelinePatchInput body, Action<RequestConfiguration<WithPipelineItemRequestBuilderPatchQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            return await RequestAdapter.SendAsync<Pipeline>(requestInfo, Pipeline.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Replace all the properties of an existing pipeline with the values provided. This will overwrite any existing pipeline stages. The updated pipeline will be returned in the response.
        /// </summary>
        /// <param name="body">An input used to create or replace a pipeline&apos;s definition.</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<Pipeline?> PutAsync(PipelineInput body, Action<RequestConfiguration<WithPipelineItemRequestBuilderPutQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<Pipeline> PutAsync(PipelineInput body, Action<RequestConfiguration<WithPipelineItemRequestBuilderPutQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPutRequestInformation(body, requestConfiguration);
            return await RequestAdapter.SendAsync<Pipeline>(requestInfo, Pipeline.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Delete the pipeline identified by `{pipelineId}`.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<WithPipelineItemRequestBuilderDeleteQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<WithPipelineItemRequestBuilderDeleteQueryParameters>> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation(Method.DELETE, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "*/*");
            return requestInfo;
        }
        /// <summary>
        /// Return a single pipeline object identified by its unique `{pipelineId}`.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Perform a partial update of the pipeline identified by `{pipelineId}`. The updated pipeline will be returned in the response.
        /// </summary>
        /// <param name="body">An input used to update some properties on a pipeline definition.</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(PipelinePatchInput body, Action<RequestConfiguration<WithPipelineItemRequestBuilderPatchQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(PipelinePatchInput body, Action<RequestConfiguration<WithPipelineItemRequestBuilderPatchQueryParameters>> requestConfiguration = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.PATCH, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Replace all the properties of an existing pipeline with the values provided. This will overwrite any existing pipeline stages. The updated pipeline will be returned in the response.
        /// </summary>
        /// <param name="body">An input used to create or replace a pipeline&apos;s definition.</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPutRequestInformation(PipelineInput body, Action<RequestConfiguration<WithPipelineItemRequestBuilderPutQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPutRequestInformation(PipelineInput body, Action<RequestConfiguration<WithPipelineItemRequestBuilderPutQueryParameters>> requestConfiguration = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.PUT, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public WithPipelineItemRequestBuilder WithUrl(string rawUrl) {
            return new WithPipelineItemRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Delete the pipeline identified by `{pipelineId}`.
        /// </summary>
        public class WithPipelineItemRequestBuilderDeleteQueryParameters {
            [QueryParameter("validateDealStageUsagesBeforeDelete")]
            public bool? ValidateDealStageUsagesBeforeDelete { get; set; }
            [QueryParameter("validateReferencesBeforeDelete")]
            public bool? ValidateReferencesBeforeDelete { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class WithPipelineItemRequestBuilderDeleteRequestConfiguration : RequestConfiguration<WithPipelineItemRequestBuilderDeleteQueryParameters> {
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class WithPipelineItemRequestBuilderGetRequestConfiguration : RequestConfiguration<DefaultQueryParameters> {
        }
        /// <summary>
        /// Perform a partial update of the pipeline identified by `{pipelineId}`. The updated pipeline will be returned in the response.
        /// </summary>
        public class WithPipelineItemRequestBuilderPatchQueryParameters {
            [QueryParameter("validateDealStageUsagesBeforeDelete")]
            public bool? ValidateDealStageUsagesBeforeDelete { get; set; }
            [QueryParameter("validateReferencesBeforeDelete")]
            public bool? ValidateReferencesBeforeDelete { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class WithPipelineItemRequestBuilderPatchRequestConfiguration : RequestConfiguration<WithPipelineItemRequestBuilderPatchQueryParameters> {
        }
        /// <summary>
        /// Replace all the properties of an existing pipeline with the values provided. This will overwrite any existing pipeline stages. The updated pipeline will be returned in the response.
        /// </summary>
        public class WithPipelineItemRequestBuilderPutQueryParameters {
            [QueryParameter("validateDealStageUsagesBeforeDelete")]
            public bool? ValidateDealStageUsagesBeforeDelete { get; set; }
            [QueryParameter("validateReferencesBeforeDelete")]
            public bool? ValidateReferencesBeforeDelete { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class WithPipelineItemRequestBuilderPutRequestConfiguration : RequestConfiguration<WithPipelineItemRequestBuilderPutQueryParameters> {
        }
    }
}
