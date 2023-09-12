using LLMSharp.Google.Palm.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using gav = Google.Ai.Generativelanguage.V1Beta2;

namespace LLMSharp.Google.Palm.DiscussService
{
    /// <summary>
    /// Implementation for DiscussService contract
    /// </summary>
    internal sealed class PalmDiscussService : IPalmDiscussService
    {
        private readonly Lazy<gav::DiscussServiceClient> _client = new(PalmClientFactory.GetDiscussServiceClient);

        /// <summary>
        /// Calls the Chat Completions Model endpoint and returns Chat Response
        /// </summary>
        /// <param name="request">Chat Request for the palm chat model</param>
        /// <param name="options">Options for customizing the request</param>
        /// <param name="token">token used for cancelling the async request</param>
        /// <returns>Chat Response with candidates</returns>
        public async Task<PalmChatCompletionResponse?> ChatAsync(PalmChatCompletionRequest request, RequestOptions? options, CancellationToken token)
        {
            var callSettings = options.GetCallSettings(token);
            var response = await _client.Value.GenerateMessageAsync(request.ToGavGenerateMessageRequest(), callSettings).ConfigureAwait(false);
            if(response != null)
            {
                return new PalmChatCompletionResponse(response);
            }

            return null;
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
            IEnumerable<PalmChatExample>? examples,
            string? context,
            string model,
            RequestOptions? reqOptions,
            CancellationToken cancellationToken)
        {
            var callSettings = reqOptions.GetCallSettings(cancellationToken);
            var result = await _client.Value.CountMessageTokensAsync(
                model,
                messages.GetMessagePrompt(context, examples),
                callSettings)
                .ConfigureAwait(false);
            return result.TokenCount;
        }        
    }
}
