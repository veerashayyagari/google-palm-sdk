using gav = Google.Ai.Generativelanguage.V1Beta2;
using static Google.Ai.Generativelanguage.V1Beta2.SafetyRating.Types;

namespace LLMSharp.Google.Palm.Common
{
    /// <summary>
    /// Safety rating for a piece of content.
    /// </summary>
    public class PalmSafetyRating
    {
        /// <summary>
        /// The category for this rating.
        /// </summary>
        public gav::HarmCategory Category { get; private set; }

        /// <summary>
        /// The probability of harm for this content.
        /// </summary>
        public HarmProbability Probability { get; private set; }

        public PalmSafetyRating(gav::HarmCategory category, HarmProbability probability)
        {
            Category = category;
            Probability = probability;
        }
    }
}
