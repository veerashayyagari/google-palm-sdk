using Google.Ai.Generativelanguage.V1Beta2;
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
        public HarmCategory Category { get; set; }

        /// <summary>
        /// The probability of harm for this content.
        /// </summary>
        public HarmProbability Probability { get; set; }
    }
}
