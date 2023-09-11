using Google.Ai.Generativelanguage.V1Beta2;
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
        public HarmCategory Category { get; set; }

        /// <summary>
        /// Controls the probability threshold at which harm is blocked.
        /// </summary>
        public HarmBlockThreshold Threshold { get; set; }
    }
}
