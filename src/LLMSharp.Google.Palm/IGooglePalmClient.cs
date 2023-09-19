using System.Threading.Tasks;
using System.Threading;
using LLMSharp.Google.Palm.DiscussService;
using System.Collections.Generic;

namespace LLMSharp.Google.Palm
{
    /// <summary>
    /// The contract implemented by GooglePalmClient SDK
    /// </summary>
    public interface IGooglePalmClient: 
        IPalmModelService, IPalmTextService, IPalmDiscussService
    {
        /// <summary>
        /// Calls the Chat Completions Model endpoint and returns Chat Response
        /// For more configurable options to ChatModel :
        /// <see cref="IPalmDiscussService.ChatAsync(PalmChatCompletionRequest, RequestOptions?, CancellationToken)"/>
        /// </summary>
        /// <param name="messages">Chronological conversation history of the messages</param>
        /// <param name="context">Optional context included in the message</param>
        /// <param name="examples">Optional examples included as part of the message</param>
        /// <param name="options">Options for customizing the request</param>
        /// <param name="token">token used for cancelling the async request</param>
        /// <returns>Chat Response with candidates</returns>
        Task<PalmChatCompletionResponse?> ChatAsync(
            IEnumerable<PalmChatMessage> messages,
            string? context,
            IEnumerable<PalmChatExample>? examples,
            RequestOptions? options = null,
            CancellationToken token = default);

        /// <summary>
        /// Calls the text completion model and returns the response.
        /// For more input options generating completion response :
        /// <see cref="IPalmTextService.GenerateTextAsync(PalmTextCompletionRequest, RequestOptions?, CancellationToken)"/>
        /// </summary>
        /// <param name="prompt">TextPrompt for generating completion</param>
        /// <param name="options">Options for the specific Grpc call</param>
        /// <param name="token">token for cancelling the request</param>
        /// <returns>TextCompletion response from the Palm Model</returns>
        Task<PalmTextCompletionResponse> GenerateTextAsync(
            string prompt,
            RequestOptions? options = null,
            CancellationToken token = default);
    }
}
