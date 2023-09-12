using LLMSharp.Google.Palm.Common;
using System.Collections.Generic;

namespace LLMSharp.Google.Palm
{
    public class PalmTextCompletionRequest
    {
        /// <summary>
        /// Which model to call
        /// Default: models/text-bison-001
        /// </summary>
        public string Model { get; set; } = Constants.DefaultPalmTextCompletionModel;

        /// <summary>
        /// Free-form input text given to the model. Given a prompt, the model will generate text that completes the input text.
        /// </summary>
        public string Prompt { get; set; } = string.Empty;

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
        /// Maximum number of tokens to include in a candidate.
        /// Must be greater than zero. 
        /// </summary>
        public int? MaxOuptputTokens { get; set; }

        /// <summary>
        /// sets the maximum number of tokens to sample from on each step.
        /// </summary>
        public int? TopK { get; set; }

        /// <summary>
        /// sets the maximum cumulative probability of tokens to sample from
        /// </summary>
        public float? TopP { get; set; }

        /// <summary>
        /// A list of unique <see cref="PalmSafetySetting"/> instances for blocking unsafe content.
        /// These will be enforced on the 'prompt' and 'candidates'
        /// There should not be more than one setting for each <see cref="PalmSafetySetting.Category"/>
        /// </summary>
        public IEnumerable<PalmSafetySetting>? SafetySettings { get; set; }

        /// <summary>
        /// A set of up to 5 character sequences that will stop output generation.
        /// If specified, the API will stop at the first appearance of a stop sequence.
        /// The stop sequence will not be included as part of the response.
        /// </summary>
        public IEnumerable<string>? StopSequences { get; set; }
    }
}
