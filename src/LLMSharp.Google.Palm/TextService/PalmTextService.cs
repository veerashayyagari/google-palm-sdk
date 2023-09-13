using Grpc.Core;
using LLMSharp.Google.Palm.Common;
using LLMSharp.Google.Palm.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using gav = Google.Ai.Generativelanguage.V1Beta2;

namespace LLMSharp.Google.Palm
{
    /// <summary>
    /// Implementation of Palm Text Service contract
    /// </summary>
    internal sealed class PalmTextService : IPalmTextService
    {
        private readonly Lazy<gav::TextServiceClient> _client = new(PalmClientFactory.GetTextServiceClient);

        /// <summary>
        /// Calls the text completion model and returns the response
        /// </summary>
        /// <param name="request">Request parameters like 'prompt', 'model' and other model response customization options</param>
        /// <param name="options">Options for the specific Grpc call</param>
        /// <param name="token">token for cancelling the request</param>
        /// <returns>TextCompletion response from the Palm Model</returns>
        public async Task<IEnumerable<float>> GenerateEmbeddingsAsync(
            string text, string model = Constants.DefaultEmbeddingModel, RequestOptions? options = null, CancellationToken token = default)
        {
            try
            {
                var settings = options.GetCallSettings(token);
                var embedTextResponse = await _client.Value.EmbedTextAsync(model, text, settings).ConfigureAwait(false);
                return embedTextResponse.Embedding.Value;
            }
            catch (RpcException ex)
            {
                throw new PalmClientException(Constants.RpcExceptionMessage, ex.InnerException, ex.Status.StatusCode, ex.Status.Detail);
            }
        }

        /// <summary>
        /// Calls the Palm Embedding Model to create an embedding for the text passed in.
        /// </summary>
        /// <param name="text">text to embed</param>
        /// <param name="model">embedding model to use</param>
        /// <param name="options">Options for the specific Grpc call</param>
        /// <param name="token">token for cancelling the request</param>
        /// <returns>list of float values (embeddings) for the text.</returns>
        public async Task<PalmTextCompletionResponse> GenerateTextAsync(
            PalmTextCompletionRequest request, RequestOptions? options, CancellationToken token = default)
        {
            try
            {
                var settings = options.GetCallSettings(token);
                var textResponse = await _client.Value.GenerateTextAsync(request.ToGavGenerateTextRequest(), settings).ConfigureAwait(false);
                return new PalmTextCompletionResponse(textResponse);
            }
            catch (RpcException ex)
            {
                throw new PalmClientException(Constants.RpcExceptionMessage, ex.InnerException, ex.Status.StatusCode, ex.Status.Detail);
            }
        }
    }
}
