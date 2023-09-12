using LLMSharp.Google.Palm.DiscussService;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LLMSharp.Google.Palm
{
    public class GooglePalmClient : IGooglePalmClient
    {
        public Task<PalmChatResponse> ChatAsync(PalmChatRequest request, RequestOptions? options = null, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountMessageTokensAsync(IReadOnlyList<PalmChatMessage> messages, IReadOnlyList<PalmChatExample>? examples = null, string? context = null, string model = "models/chat-bison-001", CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<float>> GenerateEmbeddingsAsync(
            string text, string model = Constants.DefaultPalmTextCompletionModel, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<PalmTextCompletion> GenerateTextAsync(
            GenerateTextRequest request, RequestOptions? options, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<PalmModel> GetModelAsync(string name, RequestOptions? reqOptions = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public (IEnumerable<PalmModel>, string?) ListModels(
            int pageSize = 10, string? continuationToken = null, RequestOptions? reqOptions = null)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<PalmModel> ListModelsAsync(
            RequestOptions? reqOptions = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
