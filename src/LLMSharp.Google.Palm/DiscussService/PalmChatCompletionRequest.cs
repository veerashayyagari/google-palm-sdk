using System.Collections.Generic;
using System.Linq;

namespace LLMSharp.Google.Palm.DiscussService
{
    /// <summary>
    /// Class representation of the Chat Completion Request input
    /// </summary>
    public class PalmChatCompletionRequest
    {
        /// <summary>
        /// Which model to call
        /// Default: models/chat-bison-001
        /// </summary>
        public string Model { get; set; } = Constants.DefaultPalmChatCompletionModel;

        /// <summary>
        /// Text that should be provided to the model first, to ground the response.
        /// If not empty, this context will be given to the model first before the examples and messages.
        /// This field can be a description of your prompt to the model to help provide context and guide the responses.
        /// </summary>
        public string Context { get; set; } = string.Empty;

        /// <summary>
        /// Examples of what the model should generate.
        /// This includes both the user input and the response that the model should emulate.
        /// These examples are treated identically to conversation messages except that they 
        /// take precedence over the history in messages: If the total input size exceeds the model's input_token_limit the input will be truncated. Items will be dropped from messages before examples
        /// </summary>
        public IEnumerable<PalmChatExample> Examples { get; set; } = Enumerable.Empty<PalmChatExample>();

        /// <summary>
        /// A snapshot of the conversation history sorted chronologically.
        /// Turns alternate between two authors.
        /// If the total input size exceeds the model's input_token_limit the input will be truncated: The oldest items will be dropped from messages.
        /// </summary>
        public IEnumerable<PalmChatMessage> Messages { get; set; } = Enumerable.Empty<PalmChatMessage>();

        /// <summary>
        /// Controls the randomness of the output. Must be positive. Typical values are in the range: [0.0,1.0]. 
        /// Higher values produce a more random and varied response. A temperature of zero will be deterministic.
        /// </summary>
        public float? Temperature { get; set; }

        /// <summary>
        /// The maximum number of generated response messages to return.
        /// This value must be between [1, 8], inclusive. This will default to 1.
        /// </summary>
        public int CandidateCount { get; set; } = 1;

        /// <summary>
        /// sets the maximum number of tokens to sample from on each step.
        /// </summary>
        public int? TopK { get; set; }

        /// <summary>
        /// sets the maximum cumulative probability of tokens to sample from
        /// </summary>
        public float? TopP { get; set; }
    }
}
