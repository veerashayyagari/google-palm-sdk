using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using gav = Google.Ai.Generativelanguage.V1Beta2;

namespace LLMSharp.Google.Palm
{
    internal class PalmTextService : IPalmTextService
    {
        private readonly gav::TextServiceClient _client = PalmClientFactory.GetTextServiceClient();

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
    }
}
