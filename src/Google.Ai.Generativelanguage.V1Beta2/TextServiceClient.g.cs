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
    /// <summary>Settings for <see cref="TextServiceClient"/> instances.</summary>
    public sealed partial class TextServiceSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="TextServiceSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="TextServiceSettings"/>.</returns>
        public static TextServiceSettings GetDefault() => new TextServiceSettings();

        /// <summary>Constructs a new <see cref="TextServiceSettings"/> object with default settings.</summary>
        public TextServiceSettings()
        {
        }

        private TextServiceSettings(TextServiceSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            GenerateTextSettings = existing.GenerateTextSettings;
            EmbedTextSettings = existing.EmbedTextSettings;
            OnCopy(existing);
        }

        partial void OnCopy(TextServiceSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>TextServiceClient.GenerateText</c> and <c>TextServiceClient.GenerateTextAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GenerateTextSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TextServiceClient.EmbedText</c>
        ///  and <c>TextServiceClient.EmbedTextAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings EmbedTextSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="TextServiceSettings"/> object.</returns>
        public TextServiceSettings Clone() => new TextServiceSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="TextServiceClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class TextServiceClientBuilder : gaxgrpc::ClientBuilderBase<TextServiceClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public TextServiceSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public TextServiceClientBuilder() : base(TextServiceClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref TextServiceClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<TextServiceClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override TextServiceClient Build()
        {
            TextServiceClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<TextServiceClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<TextServiceClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private TextServiceClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return TextServiceClient.Create(callInvoker, Settings, Logger);
        }

        private async stt::Task<TextServiceClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return TextServiceClient.Create(callInvoker, Settings, Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => TextServiceClient.ChannelPool;
    }

    /// <summary>TextService client wrapper, for convenient use.</summary>
    /// <remarks>
    /// API for using Generative Language Models (GLMs) trained to generate text.
    /// 
    /// Also known as Large Language Models (LLM)s, these generate text given an
    /// input prompt from the user.
    /// </remarks>
    public abstract partial class TextServiceClient
    {
        /// <summary>
        /// The default endpoint for the TextService service, which is a host of "generativelanguage.googleapis.com" and
        /// a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "generativelanguage.googleapis.com:443";

        /// <summary>The default TextService scopes.</summary>
        /// <remarks>The default TextService scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(TextService.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="TextServiceClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="TextServiceClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="TextServiceClient"/>.</returns>
        public static stt::Task<TextServiceClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new TextServiceClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="TextServiceClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="TextServiceClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="TextServiceClient"/>.</returns>
        public static TextServiceClient Create() => new TextServiceClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="TextServiceClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="TextServiceSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="TextServiceClient"/>.</returns>
        internal static TextServiceClient Create(grpccore::CallInvoker callInvoker, TextServiceSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            TextService.TextServiceClient grpcClient = new TextService.TextServiceClient(callInvoker);
            return new TextServiceClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC TextService client</summary>
        public virtual TextService.TextServiceClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Generates a response from the model given an input message.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual GenerateTextResponse GenerateText(GenerateTextRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Generates a response from the model given an input message.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<GenerateTextResponse> GenerateTextAsync(GenerateTextRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Generates a response from the model given an input message.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<GenerateTextResponse> GenerateTextAsync(GenerateTextRequest request, st::CancellationToken cancellationToken) =>
            GenerateTextAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Generates a response from the model given an input message.
        /// </summary>
        /// <param name="model">
        /// Required. The model name to use with the format name=models/{model}.
        /// </param>
        /// <param name="prompt">
        /// Required. The free-form input text given to the model as a prompt.
        /// 
        /// Given a prompt, the model will generate a TextCompletion response it
        /// predicts as the completion of the input text.
        /// </param>
        /// <param name="temperature">
        /// Controls the randomness of the output.
        /// Note: The default value varies by model, see the `Model.temperature`
        /// attribute of the `Model` returned the `getModel` function.
        /// 
        /// Values can range from [0.0,1.0],
        /// inclusive. A value closer to 1.0 will produce responses that are more
        /// varied and creative, while a value closer to 0.0 will typically result in
        /// more straightforward responses from the model.
        /// </param>
        /// <param name="candidateCount">
        /// Number of generated responses to return.
        /// 
        /// This value must be between [1, 8], inclusive. If unset, this will default
        /// to 1.
        /// </param>
        /// <param name="maxOutputTokens">
        /// The maximum number of tokens to include in a candidate.
        /// 
        /// If unset, this will default to 64.
        /// </param>
        /// <param name="topP">
        /// The maximum cumulative probability of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Tokens are sorted based on their assigned probabilities so that only the
        /// most liekly tokens are considered. Top-k sampling directly limits the
        /// maximum number of tokens to consider, while Nucleus sampling limits number
        /// of tokens based on the cumulative probability.
        /// 
        /// Note: The default value varies by model, see the `Model.top_p`
        /// attribute of the `Model` returned the `getModel` function.
        /// </param>
        /// <param name="topK">
        /// The maximum number of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// Defaults to 40.
        /// 
        /// Note: The default value varies by model, see the `Model.top_k`
        /// attribute of the `Model` returned the `getModel` function.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual GenerateTextResponse GenerateText(string model, TextPrompt prompt, float temperature, int candidateCount, int maxOutputTokens, float topP, int topK, gaxgrpc::CallSettings callSettings = null) =>
            GenerateText(new GenerateTextRequest
            {
                Model = gax::GaxPreconditions.CheckNotNullOrEmpty(model, nameof(model)),
                Prompt = gax::GaxPreconditions.CheckNotNull(prompt, nameof(prompt)),
                Temperature = temperature,
                CandidateCount = candidateCount,
                MaxOutputTokens = maxOutputTokens,
                TopP = topP,
                TopK = topK,
            }, callSettings);

        /// <summary>
        /// Generates a response from the model given an input message.
        /// </summary>
        /// <param name="model">
        /// Required. The model name to use with the format name=models/{model}.
        /// </param>
        /// <param name="prompt">
        /// Required. The free-form input text given to the model as a prompt.
        /// 
        /// Given a prompt, the model will generate a TextCompletion response it
        /// predicts as the completion of the input text.
        /// </param>
        /// <param name="temperature">
        /// Controls the randomness of the output.
        /// Note: The default value varies by model, see the `Model.temperature`
        /// attribute of the `Model` returned the `getModel` function.
        /// 
        /// Values can range from [0.0,1.0],
        /// inclusive. A value closer to 1.0 will produce responses that are more
        /// varied and creative, while a value closer to 0.0 will typically result in
        /// more straightforward responses from the model.
        /// </param>
        /// <param name="candidateCount">
        /// Number of generated responses to return.
        /// 
        /// This value must be between [1, 8], inclusive. If unset, this will default
        /// to 1.
        /// </param>
        /// <param name="maxOutputTokens">
        /// The maximum number of tokens to include in a candidate.
        /// 
        /// If unset, this will default to 64.
        /// </param>
        /// <param name="topP">
        /// The maximum cumulative probability of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Tokens are sorted based on their assigned probabilities so that only the
        /// most liekly tokens are considered. Top-k sampling directly limits the
        /// maximum number of tokens to consider, while Nucleus sampling limits number
        /// of tokens based on the cumulative probability.
        /// 
        /// Note: The default value varies by model, see the `Model.top_p`
        /// attribute of the `Model` returned the `getModel` function.
        /// </param>
        /// <param name="topK">
        /// The maximum number of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// Defaults to 40.
        /// 
        /// Note: The default value varies by model, see the `Model.top_k`
        /// attribute of the `Model` returned the `getModel` function.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<GenerateTextResponse> GenerateTextAsync(string model, TextPrompt prompt, float temperature, int candidateCount, int maxOutputTokens, float topP, int topK, gaxgrpc::CallSettings callSettings = null) =>
            GenerateTextAsync(new GenerateTextRequest
            {
                Model = gax::GaxPreconditions.CheckNotNullOrEmpty(model, nameof(model)),
                Prompt = gax::GaxPreconditions.CheckNotNull(prompt, nameof(prompt)),
                Temperature = temperature,
                CandidateCount = candidateCount,
                MaxOutputTokens = maxOutputTokens,
                TopP = topP,
                TopK = topK,
            }, callSettings);

        /// <summary>
        /// Generates a response from the model given an input message.
        /// </summary>
        /// <param name="model">
        /// Required. The model name to use with the format name=models/{model}.
        /// </param>
        /// <param name="prompt">
        /// Required. The free-form input text given to the model as a prompt.
        /// 
        /// Given a prompt, the model will generate a TextCompletion response it
        /// predicts as the completion of the input text.
        /// </param>
        /// <param name="temperature">
        /// Controls the randomness of the output.
        /// Note: The default value varies by model, see the `Model.temperature`
        /// attribute of the `Model` returned the `getModel` function.
        /// 
        /// Values can range from [0.0,1.0],
        /// inclusive. A value closer to 1.0 will produce responses that are more
        /// varied and creative, while a value closer to 0.0 will typically result in
        /// more straightforward responses from the model.
        /// </param>
        /// <param name="candidateCount">
        /// Number of generated responses to return.
        /// 
        /// This value must be between [1, 8], inclusive. If unset, this will default
        /// to 1.
        /// </param>
        /// <param name="maxOutputTokens">
        /// The maximum number of tokens to include in a candidate.
        /// 
        /// If unset, this will default to 64.
        /// </param>
        /// <param name="topP">
        /// The maximum cumulative probability of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Tokens are sorted based on their assigned probabilities so that only the
        /// most liekly tokens are considered. Top-k sampling directly limits the
        /// maximum number of tokens to consider, while Nucleus sampling limits number
        /// of tokens based on the cumulative probability.
        /// 
        /// Note: The default value varies by model, see the `Model.top_p`
        /// attribute of the `Model` returned the `getModel` function.
        /// </param>
        /// <param name="topK">
        /// The maximum number of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// Defaults to 40.
        /// 
        /// Note: The default value varies by model, see the `Model.top_k`
        /// attribute of the `Model` returned the `getModel` function.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<GenerateTextResponse> GenerateTextAsync(string model, TextPrompt prompt, float temperature, int candidateCount, int maxOutputTokens, float topP, int topK, st::CancellationToken cancellationToken) =>
            GenerateTextAsync(model, prompt, temperature, candidateCount, maxOutputTokens, topP, topK, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Generates a response from the model given an input message.
        /// </summary>
        /// <param name="model">
        /// Required. The model name to use with the format name=models/{model}.
        /// </param>
        /// <param name="prompt">
        /// Required. The free-form input text given to the model as a prompt.
        /// 
        /// Given a prompt, the model will generate a TextCompletion response it
        /// predicts as the completion of the input text.
        /// </param>
        /// <param name="temperature">
        /// Controls the randomness of the output.
        /// Note: The default value varies by model, see the `Model.temperature`
        /// attribute of the `Model` returned the `getModel` function.
        /// 
        /// Values can range from [0.0,1.0],
        /// inclusive. A value closer to 1.0 will produce responses that are more
        /// varied and creative, while a value closer to 0.0 will typically result in
        /// more straightforward responses from the model.
        /// </param>
        /// <param name="candidateCount">
        /// Number of generated responses to return.
        /// 
        /// This value must be between [1, 8], inclusive. If unset, this will default
        /// to 1.
        /// </param>
        /// <param name="maxOutputTokens">
        /// The maximum number of tokens to include in a candidate.
        /// 
        /// If unset, this will default to 64.
        /// </param>
        /// <param name="topP">
        /// The maximum cumulative probability of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Tokens are sorted based on their assigned probabilities so that only the
        /// most liekly tokens are considered. Top-k sampling directly limits the
        /// maximum number of tokens to consider, while Nucleus sampling limits number
        /// of tokens based on the cumulative probability.
        /// 
        /// Note: The default value varies by model, see the `Model.top_p`
        /// attribute of the `Model` returned the `getModel` function.
        /// </param>
        /// <param name="topK">
        /// The maximum number of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// Defaults to 40.
        /// 
        /// Note: The default value varies by model, see the `Model.top_k`
        /// attribute of the `Model` returned the `getModel` function.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual GenerateTextResponse GenerateText(ModelName model, TextPrompt prompt, float temperature, int candidateCount, int maxOutputTokens, float topP, int topK, gaxgrpc::CallSettings callSettings = null) =>
            GenerateText(new GenerateTextRequest
            {
                ModelAsModelName = gax::GaxPreconditions.CheckNotNull(model, nameof(model)),
                Prompt = gax::GaxPreconditions.CheckNotNull(prompt, nameof(prompt)),
                Temperature = temperature,
                CandidateCount = candidateCount,
                MaxOutputTokens = maxOutputTokens,
                TopP = topP,
                TopK = topK,
            }, callSettings);

        /// <summary>
        /// Generates a response from the model given an input message.
        /// </summary>
        /// <param name="model">
        /// Required. The model name to use with the format name=models/{model}.
        /// </param>
        /// <param name="prompt">
        /// Required. The free-form input text given to the model as a prompt.
        /// 
        /// Given a prompt, the model will generate a TextCompletion response it
        /// predicts as the completion of the input text.
        /// </param>
        /// <param name="temperature">
        /// Controls the randomness of the output.
        /// Note: The default value varies by model, see the `Model.temperature`
        /// attribute of the `Model` returned the `getModel` function.
        /// 
        /// Values can range from [0.0,1.0],
        /// inclusive. A value closer to 1.0 will produce responses that are more
        /// varied and creative, while a value closer to 0.0 will typically result in
        /// more straightforward responses from the model.
        /// </param>
        /// <param name="candidateCount">
        /// Number of generated responses to return.
        /// 
        /// This value must be between [1, 8], inclusive. If unset, this will default
        /// to 1.
        /// </param>
        /// <param name="maxOutputTokens">
        /// The maximum number of tokens to include in a candidate.
        /// 
        /// If unset, this will default to 64.
        /// </param>
        /// <param name="topP">
        /// The maximum cumulative probability of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Tokens are sorted based on their assigned probabilities so that only the
        /// most liekly tokens are considered. Top-k sampling directly limits the
        /// maximum number of tokens to consider, while Nucleus sampling limits number
        /// of tokens based on the cumulative probability.
        /// 
        /// Note: The default value varies by model, see the `Model.top_p`
        /// attribute of the `Model` returned the `getModel` function.
        /// </param>
        /// <param name="topK">
        /// The maximum number of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// Defaults to 40.
        /// 
        /// Note: The default value varies by model, see the `Model.top_k`
        /// attribute of the `Model` returned the `getModel` function.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<GenerateTextResponse> GenerateTextAsync(ModelName model, TextPrompt prompt, float temperature, int candidateCount, int maxOutputTokens, float topP, int topK, gaxgrpc::CallSettings callSettings = null) =>
            GenerateTextAsync(new GenerateTextRequest
            {
                ModelAsModelName = gax::GaxPreconditions.CheckNotNull(model, nameof(model)),
                Prompt = gax::GaxPreconditions.CheckNotNull(prompt, nameof(prompt)),
                Temperature = temperature,
                CandidateCount = candidateCount,
                MaxOutputTokens = maxOutputTokens,
                TopP = topP,
                TopK = topK,
            }, callSettings);

        /// <summary>
        /// Generates a response from the model given an input message.
        /// </summary>
        /// <param name="model">
        /// Required. The model name to use with the format name=models/{model}.
        /// </param>
        /// <param name="prompt">
        /// Required. The free-form input text given to the model as a prompt.
        /// 
        /// Given a prompt, the model will generate a TextCompletion response it
        /// predicts as the completion of the input text.
        /// </param>
        /// <param name="temperature">
        /// Controls the randomness of the output.
        /// Note: The default value varies by model, see the `Model.temperature`
        /// attribute of the `Model` returned the `getModel` function.
        /// 
        /// Values can range from [0.0,1.0],
        /// inclusive. A value closer to 1.0 will produce responses that are more
        /// varied and creative, while a value closer to 0.0 will typically result in
        /// more straightforward responses from the model.
        /// </param>
        /// <param name="candidateCount">
        /// Number of generated responses to return.
        /// 
        /// This value must be between [1, 8], inclusive. If unset, this will default
        /// to 1.
        /// </param>
        /// <param name="maxOutputTokens">
        /// The maximum number of tokens to include in a candidate.
        /// 
        /// If unset, this will default to 64.
        /// </param>
        /// <param name="topP">
        /// The maximum cumulative probability of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Tokens are sorted based on their assigned probabilities so that only the
        /// most liekly tokens are considered. Top-k sampling directly limits the
        /// maximum number of tokens to consider, while Nucleus sampling limits number
        /// of tokens based on the cumulative probability.
        /// 
        /// Note: The default value varies by model, see the `Model.top_p`
        /// attribute of the `Model` returned the `getModel` function.
        /// </param>
        /// <param name="topK">
        /// The maximum number of tokens to consider when sampling.
        /// 
        /// The model uses combined Top-k and nucleus sampling.
        /// 
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// Defaults to 40.
        /// 
        /// Note: The default value varies by model, see the `Model.top_k`
        /// attribute of the `Model` returned the `getModel` function.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<GenerateTextResponse> GenerateTextAsync(ModelName model, TextPrompt prompt, float temperature, int candidateCount, int maxOutputTokens, float topP, int topK, st::CancellationToken cancellationToken) =>
            GenerateTextAsync(model, prompt, temperature, candidateCount, maxOutputTokens, topP, topK, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Generates an embedding from the model given an input message.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual EmbedTextResponse EmbedText(EmbedTextRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Generates an embedding from the model given an input message.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<EmbedTextResponse> EmbedTextAsync(EmbedTextRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Generates an embedding from the model given an input message.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<EmbedTextResponse> EmbedTextAsync(EmbedTextRequest request, st::CancellationToken cancellationToken) =>
            EmbedTextAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Generates an embedding from the model given an input message.
        /// </summary>
        /// <param name="model">
        /// Required. The model name to use with the format model=models/{model}.
        /// </param>
        /// <param name="text">
        /// Required. The free-form input text that the model will turn into an
        /// embedding.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual EmbedTextResponse EmbedText(string model, string text, gaxgrpc::CallSettings callSettings = null) =>
            EmbedText(new EmbedTextRequest
            {
                Model = gax::GaxPreconditions.CheckNotNullOrEmpty(model, nameof(model)),
                Text = gax::GaxPreconditions.CheckNotNullOrEmpty(text, nameof(text)),
            }, callSettings);

        /// <summary>
        /// Generates an embedding from the model given an input message.
        /// </summary>
        /// <param name="model">
        /// Required. The model name to use with the format model=models/{model}.
        /// </param>
        /// <param name="text">
        /// Required. The free-form input text that the model will turn into an
        /// embedding.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<EmbedTextResponse> EmbedTextAsync(string model, string text, gaxgrpc::CallSettings callSettings = null) =>
            EmbedTextAsync(new EmbedTextRequest
            {
                Model = gax::GaxPreconditions.CheckNotNullOrEmpty(model, nameof(model)),
                Text = gax::GaxPreconditions.CheckNotNullOrEmpty(text, nameof(text)),
            }, callSettings);

        /// <summary>
        /// Generates an embedding from the model given an input message.
        /// </summary>
        /// <param name="model">
        /// Required. The model name to use with the format model=models/{model}.
        /// </param>
        /// <param name="text">
        /// Required. The free-form input text that the model will turn into an
        /// embedding.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<EmbedTextResponse> EmbedTextAsync(string model, string text, st::CancellationToken cancellationToken) =>
            EmbedTextAsync(model, text, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Generates an embedding from the model given an input message.
        /// </summary>
        /// <param name="model">
        /// Required. The model name to use with the format model=models/{model}.
        /// </param>
        /// <param name="text">
        /// Required. The free-form input text that the model will turn into an
        /// embedding.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual EmbedTextResponse EmbedText(ModelName model, string text, gaxgrpc::CallSettings callSettings = null) =>
            EmbedText(new EmbedTextRequest
            {
                ModelAsModelName = gax::GaxPreconditions.CheckNotNull(model, nameof(model)),
                Text = gax::GaxPreconditions.CheckNotNullOrEmpty(text, nameof(text)),
            }, callSettings);

        /// <summary>
        /// Generates an embedding from the model given an input message.
        /// </summary>
        /// <param name="model">
        /// Required. The model name to use with the format model=models/{model}.
        /// </param>
        /// <param name="text">
        /// Required. The free-form input text that the model will turn into an
        /// embedding.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<EmbedTextResponse> EmbedTextAsync(ModelName model, string text, gaxgrpc::CallSettings callSettings = null) =>
            EmbedTextAsync(new EmbedTextRequest
            {
                ModelAsModelName = gax::GaxPreconditions.CheckNotNull(model, nameof(model)),
                Text = gax::GaxPreconditions.CheckNotNullOrEmpty(text, nameof(text)),
            }, callSettings);

        /// <summary>
        /// Generates an embedding from the model given an input message.
        /// </summary>
        /// <param name="model">
        /// Required. The model name to use with the format model=models/{model}.
        /// </param>
        /// <param name="text">
        /// Required. The free-form input text that the model will turn into an
        /// embedding.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<EmbedTextResponse> EmbedTextAsync(ModelName model, string text, st::CancellationToken cancellationToken) =>
            EmbedTextAsync(model, text, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>TextService client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// API for using Generative Language Models (GLMs) trained to generate text.
    /// 
    /// Also known as Large Language Models (LLM)s, these generate text given an
    /// input prompt from the user.
    /// </remarks>
    public sealed partial class TextServiceClientImpl : TextServiceClient
    {
        private readonly gaxgrpc::ApiCall<GenerateTextRequest, GenerateTextResponse> _callGenerateText;

        private readonly gaxgrpc::ApiCall<EmbedTextRequest, EmbedTextResponse> _callEmbedText;

        /// <summary>
        /// Constructs a client wrapper for the TextService service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="TextServiceSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public TextServiceClientImpl(TextService.TextServiceClient grpcClient, TextServiceSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            TextServiceSettings effectiveSettings = settings ?? TextServiceSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            _callGenerateText = clientHelper.BuildApiCall<GenerateTextRequest, GenerateTextResponse>("GenerateText", grpcClient.GenerateTextAsync, grpcClient.GenerateText, effectiveSettings.GenerateTextSettings).WithGoogleRequestParam("model", request => request.Model);
            Modify_ApiCall(ref _callGenerateText);
            Modify_GenerateTextApiCall(ref _callGenerateText);
            _callEmbedText = clientHelper.BuildApiCall<EmbedTextRequest, EmbedTextResponse>("EmbedText", grpcClient.EmbedTextAsync, grpcClient.EmbedText, effectiveSettings.EmbedTextSettings).WithGoogleRequestParam("model", request => request.Model);
            Modify_ApiCall(ref _callEmbedText);
            Modify_EmbedTextApiCall(ref _callEmbedText);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_GenerateTextApiCall(ref gaxgrpc::ApiCall<GenerateTextRequest, GenerateTextResponse> call);

        partial void Modify_EmbedTextApiCall(ref gaxgrpc::ApiCall<EmbedTextRequest, EmbedTextResponse> call);

        partial void OnConstruction(TextService.TextServiceClient grpcClient, TextServiceSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC TextService client</summary>
        public override TextService.TextServiceClient GrpcClient { get; }

        partial void Modify_GenerateTextRequest(ref GenerateTextRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_EmbedTextRequest(ref EmbedTextRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Generates a response from the model given an input message.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override GenerateTextResponse GenerateText(GenerateTextRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GenerateTextRequest(ref request, ref callSettings);
            return _callGenerateText.Sync(request, callSettings);
        }

        /// <summary>
        /// Generates a response from the model given an input message.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<GenerateTextResponse> GenerateTextAsync(GenerateTextRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GenerateTextRequest(ref request, ref callSettings);
            return _callGenerateText.Async(request, callSettings);
        }

        /// <summary>
        /// Generates an embedding from the model given an input message.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override EmbedTextResponse EmbedText(EmbedTextRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_EmbedTextRequest(ref request, ref callSettings);
            return _callEmbedText.Sync(request, callSettings);
        }

        /// <summary>
        /// Generates an embedding from the model given an input message.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<EmbedTextResponse> EmbedTextAsync(EmbedTextRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_EmbedTextRequest(ref request, ref callSettings);
            return _callEmbedText.Async(request, callSettings);
        }
    }
}
