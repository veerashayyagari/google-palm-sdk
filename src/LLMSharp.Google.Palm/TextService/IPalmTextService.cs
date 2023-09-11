using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LLMSharp.Google.Palm
{
    public interface IPalmTextService
    {
        /// <summary>
        /// Calls the text completion model and returns the response
        /// </summary>
        /// <param name="request">Request parameters like 'prompt', 'model' and other model response customization options</param>
        /// <param name="options">Options for the specific Grpc call</param>
        /// <param name="token">token for cancelling the request</param>
        /// <returns>TextCompletion response from the Palm Model</returns>
        public Task<PalmTextCompletion> GenerateTextAsync(GenerateTextRequest request, RequestOptions? options, CancellationToken token = default);

        /// <summary>
        /// Calls the Palm Embedding Model to create an embedding for the text passed in.
        /// </summary>
        /// <param name="text">text to embed</param>
        /// <param name="model">embedding model to use</param>
        /// <param name="token">token for cancelling the request</param>
        /// <returns>list of float values (embeddings) for the text.</returns>
        public Task<IEnumerable<float>> GenerateEmbeddingsAsync(
            string text,
            string model = Constants.DefaultPalmTextCompletionModel,
            CancellationToken token = default);        
    }
}
