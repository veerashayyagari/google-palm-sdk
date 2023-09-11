using LLMSharp.Google.Palm.Common;
using System.Collections.Generic;

namespace LLMSharp.Google.Palm
{
    public class PalmCompletionCandidate
    {
        /// <summary>
        /// The generated text returned from the model.
        /// </summary>
        public string Output { get; set; } = string.Empty;

        /// <summary>
        /// Ratings for the safety of a response. There is at most one rating per category.
        /// </summary>
        public IEnumerable<PalmSafetyRating>? SafetyRatings { get; set; }

        /// <summary>
        /// Citation information for model-generated output
        /// </summary>
        public PalmCitationMetadata? CitationMetadata { get; set; }
    }
}
