// Copyright 2023 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Generated code. DO NOT EDIT!

#pragma warning disable CS8981
using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;
using proto = Google.Protobuf;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using mel = Microsoft.Extensions.Logging;
using sys = System;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Google.Ai.Generativelanguage.V1Beta2
{
    /// <summary>Settings for <see cref="DiscussServiceClient"/> instances.</summary>
    public sealed partial class DiscussServiceSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="DiscussServiceSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="DiscussServiceSettings"/>.</returns>
        public static DiscussServiceSettings GetDefault() => new DiscussServiceSettings();

        /// <summary>Constructs a new <see cref="DiscussServiceSettings"/> object with default settings.</summary>
        public DiscussServiceSettings()
        {
        }

        private DiscussServiceSettings(DiscussServiceSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            GenerateMessageSettings = existing.GenerateMessageSettings;
            CountMessageTokensSettings = existing.CountMessageTokensSettings;
            OnCopy(existing);
        }

        partial void OnCopy(DiscussServiceSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>DiscussServiceClient.GenerateMessage</c> and <c>DiscussServiceClient.GenerateMessageAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GenerateMessageSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>DiscussServiceClient.CountMessageTokens</c> and <c>DiscussServiceClient.CountMessageTokensAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings CountMessageTokensSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="DiscussServiceSettings"/> object.</returns>
        public DiscussServiceSettings Clone() => new DiscussServiceSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="DiscussServiceClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class DiscussServiceClientBuilder : gaxgrpc::ClientBuilderBase<DiscussServiceClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public DiscussServiceSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public DiscussServiceClientBuilder() : base(DiscussServiceClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref DiscussServiceClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<DiscussServiceClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override DiscussServiceClient Build()
        {
            DiscussServiceClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<DiscussServiceClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<DiscussServiceClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private DiscussServiceClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return DiscussServiceClient.Create(callInvoker, Settings, Logger);
        }

        private async stt::Task<DiscussServiceClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return DiscussServiceClient.Create(callInvoker, Settings, Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => DiscussServiceClient.ChannelPool;
    }

    /// <summary>DiscussService client wrapper, for convenient use.</summary>
    /// <remarks>
    /// An API for using Generative Language Models (GLMs) in dialog applications.
    /// 
    /// Also known as large language models (LLMs), this API provides models that
    /// are trained for multi-turn dialog.
    /// </remarks>
    public abstract partial class DiscussServiceClient
    {
        /// <summary>
        /// The default endpoint for the DiscussService service, which is a host of "generativelanguage.googleapis.com"
        /// and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "generativelanguage.googleapis.com:443";

        /// <summary>The default DiscussService scopes.</summary>
        /// <remarks>The default DiscussService scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(DiscussService.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="DiscussServiceClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="DiscussServiceClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="DiscussServiceClient"/>.</returns>
        public static stt::Task<DiscussServiceClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new DiscussServiceClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="DiscussServiceClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="DiscussServiceClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="DiscussServiceClient"/>.</returns>
        public static DiscussServiceClient Create() => new DiscussServiceClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="DiscussServiceClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="DiscussServiceSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="DiscussServiceClient"/>.</returns>
        internal static DiscussServiceClient Create(grpccore::CallInvoker callInvoker, DiscussServiceSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            DiscussService.DiscussServiceClient grpcClient = new DiscussService.DiscussServiceClient(callInvoker);
            return new DiscussServiceClientImpl(grpcClient, settings, logger);
        }

        /// <summary>
        /// Shuts down any channels automatically created by <see cref="Create()"/> and
        /// <see cref="CreateAsync(st::CancellationToken)"/>. Channels which weren't automatically created are not
        /// affected.
        /// </summary>
        /// <remarks>
        /// After calling this method, further calls to <see cref="Create()"/> and
        /// <see cref="CreateAsync(st::CancellationToken)"/> will create new channels, which could in turn be shut down
        /// by another call to this method.
        /// </remarks>
        /// <returns>A task representing the asynchronous shutdown operation.</returns>
        public static stt::Task ShutdownDefaultChannelsAsync() => ChannelPool.ShutdownChannelsAsync();

        /// <summary>The underlying gRPC DiscussService client</summary>
        public virtual DiscussService.DiscussServiceClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Generates a response from the model given an input `MessagePrompt`.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual GenerateMessageResponse GenerateMessage(GenerateMessageRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Generates a response from the model given an input `MessagePrompt`.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<GenerateMessageResponse> GenerateMessageAsync(GenerateMessageRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Generates a response from the model given an input `MessagePrompt`.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<GenerateMessageResponse> GenerateMessageAsync(GenerateMessageRequest request, st::CancellationToken cancellationToken) =>
            GenerateMessageAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Generates a response from the model given an input `MessagePrompt`.
        /// </summary>
        /// <param name="model">
        /// Required. The name of the model to use.
        /// 
        /// Format: `name=models/{model}`.
        /// </param>
        /// <param name="prompt">
        /// Required. The structured textual input given to the model as a prompt.
        /// 
        /// Given a
        /// prompt, the model will return what it predicts is the next message in the
        /// discussion.
        /// </param>
        /// <param name="temperature">
        /// Optional. Controls the randomness of the output.
        /// 
        /// Values can range over `[0.0,1.0]`,
        /// inclusive. A value closer to `1.0` will produce responses that are more
        /// varied, while a value closer to `0.0` will typically result in
        /// less surprising responses from the model.
        /// </param>
        /// <param name="candidateCount">
        /// Optional. The number of generated response messages to return.
        /// 
        /// This value must be between
        /// `[1, 8]`, inclusive. If unset, this will default to `1`.
        /// </param>
        /// <param name="topP">
        /// Optional. The maximum cumulative probability of tokens to consider when
        /// sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Nucleus sampling considers the smallest set of tokens whose probability
        /// sum is at least `top_p`.
        /// </param>
        /// <param name="topK">
        /// Optional. The maximum number of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual GenerateMessageResponse GenerateMessage(string model, MessagePrompt prompt, float temperature, int candidateCount, float topP, int topK, gaxgrpc::CallSettings callSettings = null) =>
            GenerateMessage(new GenerateMessageRequest
            {
                Model = gax::GaxPreconditions.CheckNotNullOrEmpty(model, nameof(model)),
                Prompt = gax::GaxPreconditions.CheckNotNull(prompt, nameof(prompt)),
                Temperature = temperature,
                CandidateCount = candidateCount,
                TopP = topP,
                TopK = topK,
            }, callSettings);

        /// <summary>
        /// Generates a response from the model given an input `MessagePrompt`.
        /// </summary>
        /// <param name="model">
        /// Required. The name of the model to use.
        /// 
        /// Format: `name=models/{model}`.
        /// </param>
        /// <param name="prompt">
        /// Required. The structured textual input given to the model as a prompt.
        /// 
        /// Given a
        /// prompt, the model will return what it predicts is the next message in the
        /// discussion.
        /// </param>
        /// <param name="temperature">
        /// Optional. Controls the randomness of the output.
        /// 
        /// Values can range over `[0.0,1.0]`,
        /// inclusive. A value closer to `1.0` will produce responses that are more
        /// varied, while a value closer to `0.0` will typically result in
        /// less surprising responses from the model.
        /// </param>
        /// <param name="candidateCount">
        /// Optional. The number of generated response messages to return.
        /// 
        /// This value must be between
        /// `[1, 8]`, inclusive. If unset, this will default to `1`.
        /// </param>
        /// <param name="topP">
        /// Optional. The maximum cumulative probability of tokens to consider when
        /// sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Nucleus sampling considers the smallest set of tokens whose probability
        /// sum is at least `top_p`.
        /// </param>
        /// <param name="topK">
        /// Optional. The maximum number of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<GenerateMessageResponse> GenerateMessageAsync(string model, MessagePrompt prompt, float temperature, int candidateCount, float topP, int topK, gaxgrpc::CallSettings callSettings = null) =>
            GenerateMessageAsync(new GenerateMessageRequest
            {
                Model = gax::GaxPreconditions.CheckNotNullOrEmpty(model, nameof(model)),
                Prompt = gax::GaxPreconditions.CheckNotNull(prompt, nameof(prompt)),
                Temperature = temperature,
                CandidateCount = candidateCount,
                TopP = topP,
                TopK = topK,
            }, callSettings);

        /// <summary>
        /// Generates a response from the model given an input `MessagePrompt`.
        /// </summary>
        /// <param name="model">
        /// Required. The name of the model to use.
        /// 
        /// Format: `name=models/{model}`.
        /// </param>
        /// <param name="prompt">
        /// Required. The structured textual input given to the model as a prompt.
        /// 
        /// Given a
        /// prompt, the model will return what it predicts is the next message in the
        /// discussion.
        /// </param>
        /// <param name="temperature">
        /// Optional. Controls the randomness of the output.
        /// 
        /// Values can range over `[0.0,1.0]`,
        /// inclusive. A value closer to `1.0` will produce responses that are more
        /// varied, while a value closer to `0.0` will typically result in
        /// less surprising responses from the model.
        /// </param>
        /// <param name="candidateCount">
        /// Optional. The number of generated response messages to return.
        /// 
        /// This value must be between
        /// `[1, 8]`, inclusive. If unset, this will default to `1`.
        /// </param>
        /// <param name="topP">
        /// Optional. The maximum cumulative probability of tokens to consider when
        /// sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Nucleus sampling considers the smallest set of tokens whose probability
        /// sum is at least `top_p`.
        /// </param>
        /// <param name="topK">
        /// Optional. The maximum number of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<GenerateMessageResponse> GenerateMessageAsync(string model, MessagePrompt prompt, float temperature, int candidateCount, float topP, int topK, st::CancellationToken cancellationToken) =>
            GenerateMessageAsync(model, prompt, temperature, candidateCount, topP, topK, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Generates a response from the model given an input `MessagePrompt`.
        /// </summary>
        /// <param name="model">
        /// Required. The name of the model to use.
        /// 
        /// Format: `name=models/{model}`.
        /// </param>
        /// <param name="prompt">
        /// Required. The structured textual input given to the model as a prompt.
        /// 
        /// Given a
        /// prompt, the model will return what it predicts is the next message in the
        /// discussion.
        /// </param>
        /// <param name="temperature">
        /// Optional. Controls the randomness of the output.
        /// 
        /// Values can range over `[0.0,1.0]`,
        /// inclusive. A value closer to `1.0` will produce responses that are more
        /// varied, while a value closer to `0.0` will typically result in
        /// less surprising responses from the model.
        /// </param>
        /// <param name="candidateCount">
        /// Optional. The number of generated response messages to return.
        /// 
        /// This value must be between
        /// `[1, 8]`, inclusive. If unset, this will default to `1`.
        /// </param>
        /// <param name="topP">
        /// Optional. The maximum cumulative probability of tokens to consider when
        /// sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Nucleus sampling considers the smallest set of tokens whose probability
        /// sum is at least `top_p`.
        /// </param>
        /// <param name="topK">
        /// Optional. The maximum number of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual GenerateMessageResponse GenerateMessage(ModelName model, MessagePrompt prompt, float temperature, int candidateCount, float topP, int topK, gaxgrpc::CallSettings callSettings = null) =>
            GenerateMessage(new GenerateMessageRequest
            {
                ModelAsModelName = gax::GaxPreconditions.CheckNotNull(model, nameof(model)),
                Prompt = gax::GaxPreconditions.CheckNotNull(prompt, nameof(prompt)),
                Temperature = temperature,
                CandidateCount = candidateCount,
                TopP = topP,
                TopK = topK,
            }, callSettings);

        /// <summary>
        /// Generates a response from the model given an input `MessagePrompt`.
        /// </summary>
        /// <param name="model">
        /// Required. The name of the model to use.
        /// 
        /// Format: `name=models/{model}`.
        /// </param>
        /// <param name="prompt">
        /// Required. The structured textual input given to the model as a prompt.
        /// 
        /// Given a
        /// prompt, the model will return what it predicts is the next message in the
        /// discussion.
        /// </param>
        /// <param name="temperature">
        /// Optional. Controls the randomness of the output.
        /// 
        /// Values can range over `[0.0,1.0]`,
        /// inclusive. A value closer to `1.0` will produce responses that are more
        /// varied, while a value closer to `0.0` will typically result in
        /// less surprising responses from the model.
        /// </param>
        /// <param name="candidateCount">
        /// Optional. The number of generated response messages to return.
        /// 
        /// This value must be between
        /// `[1, 8]`, inclusive. If unset, this will default to `1`.
        /// </param>
        /// <param name="topP">
        /// Optional. The maximum cumulative probability of tokens to consider when
        /// sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Nucleus sampling considers the smallest set of tokens whose probability
        /// sum is at least `top_p`.
        /// </param>
        /// <param name="topK">
        /// Optional. The maximum number of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<GenerateMessageResponse> GenerateMessageAsync(ModelName model, MessagePrompt prompt, float temperature, int candidateCount, float topP, int topK, gaxgrpc::CallSettings callSettings = null) =>
            GenerateMessageAsync(new GenerateMessageRequest
            {
                ModelAsModelName = gax::GaxPreconditions.CheckNotNull(model, nameof(model)),
                Prompt = gax::GaxPreconditions.CheckNotNull(prompt, nameof(prompt)),
                Temperature = temperature,
                CandidateCount = candidateCount,
                TopP = topP,
                TopK = topK,
            }, callSettings);

        /// <summary>
        /// Generates a response from the model given an input `MessagePrompt`.
        /// </summary>
        /// <param name="model">
        /// Required. The name of the model to use.
        /// 
        /// Format: `name=models/{model}`.
        /// </param>
        /// <param name="prompt">
        /// Required. The structured textual input given to the model as a prompt.
        /// 
        /// Given a
        /// prompt, the model will return what it predicts is the next message in the
        /// discussion.
        /// </param>
        /// <param name="temperature">
        /// Optional. Controls the randomness of the output.
        /// 
        /// Values can range over `[0.0,1.0]`,
        /// inclusive. A value closer to `1.0` will produce responses that are more
        /// varied, while a value closer to `0.0` will typically result in
        /// less surprising responses from the model.
        /// </param>
        /// <param name="candidateCount">
        /// Optional. The number of generated response messages to return.
        /// 
        /// This value must be between
        /// `[1, 8]`, inclusive. If unset, this will default to `1`.
        /// </param>
        /// <param name="topP">
        /// Optional. The maximum cumulative probability of tokens to consider when
        /// sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Nucleus sampling considers the smallest set of tokens whose probability
        /// sum is at least `top_p`.
        /// </param>
        /// <param name="topK">
        /// Optional. The maximum number of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<GenerateMessageResponse> GenerateMessageAsync(ModelName model, MessagePrompt prompt, float temperature, int candidateCount, float topP, int topK, st::CancellationToken cancellationToken) =>
            GenerateMessageAsync(model, prompt, temperature, candidateCount, topP, topK, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Runs a model's tokenizer on a string and returns the token count.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual CountMessageTokensResponse CountMessageTokens(CountMessageTokensRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Runs a model's tokenizer on a string and returns the token count.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<CountMessageTokensResponse> CountMessageTokensAsync(CountMessageTokensRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Runs a model's tokenizer on a string and returns the token count.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<CountMessageTokensResponse> CountMessageTokensAsync(CountMessageTokensRequest request, st::CancellationToken cancellationToken) =>
            CountMessageTokensAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Runs a model's tokenizer on a string and returns the token count.
        /// </summary>
        /// <param name="model">
        /// Required. The model's resource name. This serves as an ID for the Model to
        /// use.
        /// 
        /// This name should match a model name returned by the `ListModels` method.
        /// 
        /// Format: `models/{model}`
        /// </param>
        /// <param name="prompt">
        /// Required. The prompt, whose token count is to be returned.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual CountMessageTokensResponse CountMessageTokens(string model, MessagePrompt prompt, gaxgrpc::CallSettings callSettings = null) =>
            CountMessageTokens(new CountMessageTokensRequest
            {
                Model = gax::GaxPreconditions.CheckNotNullOrEmpty(model, nameof(model)),
                Prompt = gax::GaxPreconditions.CheckNotNull(prompt, nameof(prompt)),
            }, callSettings);

        /// <summary>
        /// Runs a model's tokenizer on a string and returns the token count.
        /// </summary>
        /// <param name="model">
        /// Required. The model's resource name. This serves as an ID for the Model to
        /// use.
        /// 
        /// This name should match a model name returned by the `ListModels` method.
        /// 
        /// Format: `models/{model}`
        /// </param>
        /// <param name="prompt">
        /// Required. The prompt, whose token count is to be returned.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<CountMessageTokensResponse> CountMessageTokensAsync(string model, MessagePrompt prompt, gaxgrpc::CallSettings callSettings = null) =>
            CountMessageTokensAsync(new CountMessageTokensRequest
            {
                Model = gax::GaxPreconditions.CheckNotNullOrEmpty(model, nameof(model)),
                Prompt = gax::GaxPreconditions.CheckNotNull(prompt, nameof(prompt)),
            }, callSettings);

        /// <summary>
        /// Runs a model's tokenizer on a string and returns the token count.
        /// </summary>
        /// <param name="model">
        /// Required. The model's resource name. This serves as an ID for the Model to
        /// use.
        /// 
        /// This name should match a model name returned by the `ListModels` method.
        /// 
        /// Format: `models/{model}`
        /// </param>
        /// <param name="prompt">
        /// Required. The prompt, whose token count is to be returned.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<CountMessageTokensResponse> CountMessageTokensAsync(string model, MessagePrompt prompt, st::CancellationToken cancellationToken) =>
            CountMessageTokensAsync(model, prompt, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Runs a model's tokenizer on a string and returns the token count.
        /// </summary>
        /// <param name="model">
        /// Required. The model's resource name. This serves as an ID for the Model to
        /// use.
        /// 
        /// This name should match a model name returned by the `ListModels` method.
        /// 
        /// Format: `models/{model}`
        /// </param>
        /// <param name="prompt">
        /// Required. The prompt, whose token count is to be returned.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual CountMessageTokensResponse CountMessageTokens(ModelName model, MessagePrompt prompt, gaxgrpc::CallSettings callSettings = null) =>
            CountMessageTokens(new CountMessageTokensRequest
            {
                ModelAsModelName = gax::GaxPreconditions.CheckNotNull(model, nameof(model)),
                Prompt = gax::GaxPreconditions.CheckNotNull(prompt, nameof(prompt)),
            }, callSettings);

        /// <summary>
        /// Runs a model's tokenizer on a string and returns the token count.
        /// </summary>
        /// <param name="model">
        /// Required. The model's resource name. This serves as an ID for the Model to
        /// use.
        /// 
        /// This name should match a model name returned by the `ListModels` method.
        /// 
        /// Format: `models/{model}`
        /// </param>
        /// <param name="prompt">
        /// Required. The prompt, whose token count is to be returned.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<CountMessageTokensResponse> CountMessageTokensAsync(ModelName model, MessagePrompt prompt, gaxgrpc::CallSettings callSettings = null) =>
            CountMessageTokensAsync(new CountMessageTokensRequest
            {
                ModelAsModelName = gax::GaxPreconditions.CheckNotNull(model, nameof(model)),
                Prompt = gax::GaxPreconditions.CheckNotNull(prompt, nameof(prompt)),
            }, callSettings);

        /// <summary>
        /// Runs a model's tokenizer on a string and returns the token count.
        /// </summary>
        /// <param name="model">
        /// Required. The model's resource name. This serves as an ID for the Model to
        /// use.
        /// 
        /// This name should match a model name returned by the `ListModels` method.
        /// 
        /// Format: `models/{model}`
        /// </param>
        /// <param name="prompt">
        /// Required. The prompt, whose token count is to be returned.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<CountMessageTokensResponse> CountMessageTokensAsync(ModelName model, MessagePrompt prompt, st::CancellationToken cancellationToken) =>
            CountMessageTokensAsync(model, prompt, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>DiscussService client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// An API for using Generative Language Models (GLMs) in dialog applications.
    /// 
    /// Also known as large language models (LLMs), this API provides models that
    /// are trained for multi-turn dialog.
    /// </remarks>
    public sealed partial class DiscussServiceClientImpl : DiscussServiceClient
    {
        private readonly gaxgrpc::ApiCall<GenerateMessageRequest, GenerateMessageResponse> _callGenerateMessage;

        private readonly gaxgrpc::ApiCall<CountMessageTokensRequest, CountMessageTokensResponse> _callCountMessageTokens;

        /// <summary>
        /// Constructs a client wrapper for the DiscussService service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="DiscussServiceSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public DiscussServiceClientImpl(DiscussService.DiscussServiceClient grpcClient, DiscussServiceSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            DiscussServiceSettings effectiveSettings = settings ?? DiscussServiceSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            _callGenerateMessage = clientHelper.BuildApiCall<GenerateMessageRequest, GenerateMessageResponse>("GenerateMessage", grpcClient.GenerateMessageAsync, grpcClient.GenerateMessage, effectiveSettings.GenerateMessageSettings).WithGoogleRequestParam("model", request => request.Model);
            Modify_ApiCall(ref _callGenerateMessage);
            Modify_GenerateMessageApiCall(ref _callGenerateMessage);
            _callCountMessageTokens = clientHelper.BuildApiCall<CountMessageTokensRequest, CountMessageTokensResponse>("CountMessageTokens", grpcClient.CountMessageTokensAsync, grpcClient.CountMessageTokens, effectiveSettings.CountMessageTokensSettings).WithGoogleRequestParam("model", request => request.Model);
            Modify_ApiCall(ref _callCountMessageTokens);
            Modify_CountMessageTokensApiCall(ref _callCountMessageTokens);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_GenerateMessageApiCall(ref gaxgrpc::ApiCall<GenerateMessageRequest, GenerateMessageResponse> call);

        partial void Modify_CountMessageTokensApiCall(ref gaxgrpc::ApiCall<CountMessageTokensRequest, CountMessageTokensResponse> call);

        partial void OnConstruction(DiscussService.DiscussServiceClient grpcClient, DiscussServiceSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC DiscussService client</summary>
        public override DiscussService.DiscussServiceClient GrpcClient { get; }

        partial void Modify_GenerateMessageRequest(ref GenerateMessageRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_CountMessageTokensRequest(ref CountMessageTokensRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Generates a response from the model given an input `MessagePrompt`.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override GenerateMessageResponse GenerateMessage(GenerateMessageRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GenerateMessageRequest(ref request, ref callSettings);
            return _callGenerateMessage.Sync(request, callSettings);
        }

        /// <summary>
        /// Generates a response from the model given an input `MessagePrompt`.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<GenerateMessageResponse> GenerateMessageAsync(GenerateMessageRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GenerateMessageRequest(ref request, ref callSettings);
            return _callGenerateMessage.Async(request, callSettings);
        }

        /// <summary>
        /// Runs a model's tokenizer on a string and returns the token count.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override CountMessageTokensResponse CountMessageTokens(CountMessageTokensRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CountMessageTokensRequest(ref request, ref callSettings);
            return _callCountMessageTokens.Sync(request, callSettings);
        }

        /// <summary>
        /// Runs a model's tokenizer on a string and returns the token count.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<CountMessageTokensResponse> CountMessageTokensAsync(CountMessageTokensRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CountMessageTokensRequest(ref request, ref callSettings);
            return _callCountMessageTokens.Async(request, callSettings);
        }
    }
}
