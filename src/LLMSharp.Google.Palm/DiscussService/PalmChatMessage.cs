using Google.Ai.Generativelanguage.V1Beta2;

namespace LLMSharp.Google.Palm
{
    public class PalmChatMessage
    {
        /// <summary>
        /// Optional. The author of this Message.
        ///
        /// This serves as a key for tagging
        /// the content of this Message when it is fed to the model as text.
        ///
        /// The author can be any alphanumeric string.
        /// </summary>
        public string? Author { get; set; }

        /// <summary>
        /// Required. The text content of the structured `Message`.
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Output only. Citation information for model-generated `content` in this
        /// `Message`.
        /// </summary>
        public CitationMetadata? CitationMetadata { get; set; }
    }
}
