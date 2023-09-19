using gav = Google.Ai.Generativelanguage.V1Beta2;

namespace LLMSharp.Google.Palm.Common
{
    /// <summary>
    /// Safety feedback for an entire request.
    /// </summary>
    public class PalmSafetyFeedback
    {
        /// <summary>
        /// Safety rating evaluated from content.
        /// </summary>
        public PalmSafetyRating? Rating { get; private set; }

        /// <summary>
        /// Safety settings applied to the request.
        /// </summary>
        public PalmSafetySetting? Setting { get; private set; }

        internal PalmSafetyFeedback(gav::SafetyFeedback feedback)
        {
            this.Setting = new PalmSafetySetting(feedback.Setting.Category, feedback.Setting.Threshold);
            this.Rating = new PalmSafetyRating(feedback.Rating.Category,feedback.Rating.Probability);
        }
    }
}
