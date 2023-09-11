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
        public PalmSafetyRating? Rating { get; set; }

        /// <summary>
        /// Safety settings applied to the request.
        /// </summary>
        public PalmSafetySetting? Setting { get; set; }
    }
}
