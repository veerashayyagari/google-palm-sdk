using LLMSharp.Google.Palm.DiscussService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LLMSharp.Google.Palm
{
    /// <summary>
    /// Contract implemented for the Palm Discuss Service
    /// </summary>
    public interface IPalmDiscussService
    {
        /// <summary>
        /// Calls the Chat Completions Model endpoint and returns Chat Response
        /// </summary>
        /// <param name="request">Chat Request for the palm chat model</param>
        /// <param name="options">Options for customizing the request</param>
        /// <param name="token">token used for cancelling the async request</param>
        /// <returns>Chat Response with candidates</returns>
        public Task<PalmChatCompletionResponse?> ChatAsync(PalmChatCompletionRequest request,
            RequestOptions? options,
            CancellationToken token);

        /// <summary>
        /// Count total number of message tokens given a message with optional context and examples
        /// </summary>
        /// <param name="messages">Chronological conversation history of the messages</param>
        /// <param name="examples">Optional examples included as part of the message</param>
        /// <param name="context">Optional context included in the message</param>
        /// <param name="model">Model used for counting tokens. Default: models/chat-bison-001</param>
        /// <param name="reqOptions">Options for customizing the request</param>
        /// <param name="cancellationToken">token used for cancelling the async request</param>
        /// <returns>message token count</returns>
        public Task<int> CountMessageTokensAsync(
            IEnumerable<PalmChatMessage> messages,
            IEnumerable<PalmChatExample>? examples,
            string? context,
            string model,
            RequestOptions? reqOptions,
            CancellationToken cancellationToken);
    }
}
