using LLMSharp.Google.Palm.DiscussService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LLMSharp.Google.Palm
{
    /// <summary>
    /// Client SDK implementation for Google Palm Models
    /// </summary>
    public class GooglePalmClient : IGooglePalmClient
    {
        private readonly IPalmModelService _palmModelService;
        private readonly IPalmTextService _palmTextService;
        private readonly IPalmDiscussService _palmDiscussService;

        /// <summary>
        /// Constructor for GooglePalmClient with ApiKey        
        /// </summary>
        /// <param name="apiKey">if apikey is null, looks for the environment variable <see cref="Constants.PalmApiKeyEnvVar"/></param>
        public GooglePalmClient(string? apiKey = null) :
            this(new ClientOptions { ApiKey = apiKey ?? Environment.GetEnvironmentVariable(Constants.PalmApiKeyEnvVar) })
        {
        }

        /// <summary>
        /// Construct GooglePalmClient with custom client options
        /// </summary>
        /// <param name="options">Options for customization</param>
        public GooglePalmClient(ClientOptions options)
        {
            PalmClientFactory.Initialize(options);
            this._palmModelService = new PalmModelService();
            this._palmTextService = new PalmTextService();
            this._palmDiscussService = new PalmDiscussService();
        }

        /// <summary>
        /// Calls the Chat Completions Model endpoint and returns Chat Response
        /// </summary>
        /// <param name="messages">Chronological conversation history of the messages</param>
        /// <param name="context">Optional context included in the message</param>
        /// <param name="examples">Optional examples included as part of the message</param>
        /// <param name="options">Options for customizing the request</param>
        /// <param name="token">token used for cancelling the async request</param>
        /// <returns>Chat Response with candidates</returns>
        public async Task<PalmChatCompletionResponse?> ChatAsync(            
            IEnumerable<PalmChatMessage> messages,
            string? context,
            IEnumerable<PalmChatExample>? examples,
            RequestOptions? options = null,
            CancellationToken token = default)
        {
            return await this.ChatAsync(
                new PalmChatCompletionRequest { 
                    Messages = messages,
                    Context = context ?? string.Empty,
                    Examples = examples ?? Enumerable.Empty<PalmChatExample>() 
                },
                options,
                token).ConfigureAwait(false);
        }

        /// <summary>
        /// Calls the Chat Completions Model endpoint and returns Chat Response
        /// </summary>
        /// <param name="request">Chat Request for the palm chat model</param>
        /// <param name="options">Options for customizing the request</param>
        /// <param name="token">token used for cancelling the async request</param>
        /// <returns>Chat Response with candidates</returns>
        public async Task<PalmChatCompletionResponse?> ChatAsync(
            PalmChatCompletionRequest request,
            RequestOptions? options = null,
            CancellationToken token = default)
        {
            return await this._palmDiscussService.ChatAsync(request, options, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Count total number of message tokens given a message with optional context and examples
        /// </summary>
        /// <param name="messages">Chronological conversation history of the messages</param>
        /// <param name="examples">Optional examples included as part of the message</param>
        /// <param name="context">Optional context included in the message</param>
        /// <param name="model">Model used for counting tokens. Default: models/chat-bison-001</param>
        /// <param name="options">Options for customizing the request</param>
        /// <param name="cancellationToken">token used for cancelling the async request</param>
        /// <returns>message token count</returns>
        public async Task<int> CountMessageTokensAsync(
            IEnumerable<PalmChatMessage> messages,
            IEnumerable<PalmChatExample>? examples = null,
            string? context = null,
            string model = Constants.DefaultPalmChatCompletionModel,
            RequestOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            return await this._palmDiscussService.CountMessageTokensAsync(
                messages,
                examples ?? Enumerable.Empty<PalmChatExample>(),
                context,
                model,
                options,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Calls the Palm Embedding Model to create an embedding for the text passed in.
        /// </summary>
        /// <param name="text">text to embed</param>
        /// <param name="model">embedding model to use</param>
        /// <param name="options">Options for the specific Grpc call</param>
        /// <param name="token">token for cancelling the request</param>
        /// <returns>list of float values (embeddings) for the text.</returns>
        public async Task<IEnumerable<float>> GenerateEmbeddingsAsync(
            string text,
            string model = Constants.DefaultEmbeddingModel,
            RequestOptions? options = null,
            CancellationToken token = default)
        {
            return await this._palmTextService.GenerateEmbeddingsAsync(text, model, options, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Calls the text completion model and returns the response.
        /// For more input options generating completion response :
        /// <see cref="GenerateTextAsync(PalmTextCompletionRequest, RequestOptions?, CancellationToken)"/>
        /// </summary>
        /// <param name="prompt">TextPrompt for generating completion</param>
        /// <param name="options">Options for the specific Grpc call</param>
        /// <param name="token">token for cancelling the request</param>
        /// <returns>TextCompletion response from the Palm Model</returns>
        public async Task<PalmTextCompletionResponse> GenerateTextAsync(
            string prompt,
            RequestOptions? options = null,
            CancellationToken token = default)
        {
            return await this._palmTextService.GenerateTextAsync(
                new PalmTextCompletionRequest { Prompt = prompt }, options, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Calls the text completion model and returns the response
        /// </summary>
        /// <param name="request">Request parameters like 'prompt', 'model' and other model response customization options</param>
        /// <param name="options">Options for the specific Grpc call</param>
        /// <param name="token">token for cancelling the request</param>
        /// <returns>TextCompletion response from the Palm Model</returns>
        public async Task<PalmTextCompletionResponse> GenerateTextAsync(
            PalmTextCompletionRequest request,
            RequestOptions? options = null,
            CancellationToken token = default)
        {
            return await this._palmTextService.GenerateTextAsync(request, options, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the Palm Model for the given model name
        /// </summary>
        /// <param name="name">Palm Model name</param>
        /// <param name="reqOptions">Request specific options to configure</param>
        /// <param name="cancellationToken">Token to cancel the async fetch of model</param>
        /// <returns>Palm Model details</returns>
        public async Task<PalmModel> GetModelAsync(
            string name, RequestOptions? reqOptions = null, CancellationToken cancellationToken = default)
        {
            return await this._palmModelService.GetModelAsync(name, reqOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// fetch available palm models by page
        /// </summary>
        /// <param name="pageSize">page size to fetch, default: 10</param>
        /// <param name="continuationToken">continuationToken to use for fetching subsequent pages</param>
        /// <param name="reqOptions">Request specific options to configure</param>
        /// <returns>Iterable enumeration of Palm Models and any continuation token to use for next page</returns>
        public (IEnumerable<PalmModel>, string?) ListModels(
            int pageSize = 10, string? continuationToken = null, RequestOptions? reqOptions = null)
        {
            return this._palmModelService.ListModels(pageSize, continuationToken, reqOptions);
        }

        /// <summary>
        /// fetch a stream of available of palm models
        /// </summary>
        /// <param name="reqOptions">Request specific options to configure</param>
        /// <param name="cancellationToken">Token to cancel the async fetch of models</param>
        /// <returns>An AsyncEnumerable stream of palm models</returns>
        public IAsyncEnumerable<PalmModel> ListModelsAsync(
            RequestOptions? reqOptions = null, CancellationToken cancellationToken = default)
        {
            return this._palmModelService.ListModelsAsync(reqOptions, cancellationToken);
        }
    }
}
