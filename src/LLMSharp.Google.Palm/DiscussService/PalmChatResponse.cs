using System;
using System.Collections.Generic;
using System.Text;

namespace LLMSharp.Google.Palm.DiscussService
{
    public class PalmChatResponse
    {
        /// <summary>
        /// A list of candidate responses from the model.
        /// The top candidate is appended to the messages field.
        /// </summary>
        public IReadOnlyList<PalmCompletionCandidate>? Candidates { get; set; }

        /// <summary>
        /// A snapshot of the conversation history sorted chronologically.
        /// </summary>
        public IReadOnlyList<string> Messages { get; set; } = new List<string>();

        /// <summary>
        /// Model that responded
        /// </summary>
        public string Model { get; set; } = Constants.DefaultPalmChatCompletionModel;

        /// <summary>
        /// Controls the randomness of the output.
        /// </summary>
        public float Temperature { get; set; }

        /// <summary>
        /// The maximum number of generated response messages to return.
        /// </summary>
        public int CandidateCount { get; set; }
    }
}
