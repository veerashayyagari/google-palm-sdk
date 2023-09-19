using gav = Google.Ai.Generativelanguage.V1Beta2;
using LLMSharp.Google.Palm.Common;
using System.Collections.Generic;
using System.Linq;

namespace LLMSharp.Google.Palm
{
    public class PalmCompletionCandidate
    {
        internal PalmCompletionCandidate(gav::TextCompletion c)
        {
            this.Output = c.Output;
            this.SafetyRatings = c.SafetyRatings.Select(r => new PalmSafetyRating(r.Category, r.Probability));
            this.CitationMetadata = new PalmCitationMetadata(c.CitationMetadata);
        }

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
