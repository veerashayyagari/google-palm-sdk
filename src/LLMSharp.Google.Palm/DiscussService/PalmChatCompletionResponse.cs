using gav = Google.Ai.Generativelanguage.V1Beta2;
using LLMSharp.Google.Palm.Common;
using System.Collections.Generic;
using System.Linq;

namespace LLMSharp.Google.Palm.DiscussService
{
    /// <summary>
    /// Class representing the response from a Palm Chat Completion Request
    /// </summary>
    public class PalmChatCompletionResponse
    {
        internal PalmChatCompletionResponse(gav::GenerateMessageResponse response)
        {
            this.Candidates = response.Candidates.Select(c => new PalmChatMessage(c)).ToList();
            this.Messages = response.Messages.Select(m => new PalmChatMessage(m)).ToList();
            this.Filters = response.Filters.Select(f => new PalmContentFilter(f));
        }

        /// <summary>
        /// A list of candidate responses from the model.
        /// The top candidate is appended to the messages field.
        /// </summary>
        public IReadOnlyList<PalmChatMessage> Candidates { get; private set; } = new List<PalmChatMessage>();

        /// <summary>
        /// A snapshot of the conversation history sorted chronologically.
        /// </summary>
        public IReadOnlyList<PalmChatMessage> Messages { get; private set; } = new List<PalmChatMessage>();

        /// <summary>
        /// Indicates the reasons why content may have been blocked.
        /// </summary>
        public IEnumerable<PalmContentFilter> Filters { get; private set; } = Enumerable.Empty<PalmContentFilter>();        
    }
}
