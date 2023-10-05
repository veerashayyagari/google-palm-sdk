using gav = Google.Ai.Generativelanguage.V1Beta2;
using static Google.Ai.Generativelanguage.V1Beta2.SafetySetting.Types;

namespace LLMSharp.Google.Palm.Common
{
    /// <summary>
    /// Safety setting, affecting the safety-blocking behavior.
    /// </summary>
    public class PalmSafetySetting
    {
        /// <summary>
        /// The category for this setting.
        /// </summary>
        public gav::HarmCategory Category { get; private set; }

        /// <summary>
        /// Controls the probability threshold at which harm is blocked.
        /// </summary>
        public HarmBlockThreshold Threshold { get; private set; }

        /// <summary>
        /// Safety Setting constructor
        /// </summary>
        /// <param name="category">HarmCategory</param>
        /// <param name="threshold">BlockThreshold</param>
        public PalmSafetySetting(gav::HarmCategory category, HarmBlockThreshold threshold)
        {
            Category = category;
            Threshold = threshold;
        }
    }
}
