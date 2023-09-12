using LLMSharp.Google.Palm.Common;
using gav = Google.Ai.Generativelanguage.V1Beta2;

namespace LLMSharp.Google.Palm
{
    public class PalmChatMessage
    {
        internal PalmChatMessage(gav::Message c)
        {
            this.Author = c.Author;
            this.Content = c.Content;
            this.CitationMetadata = new PalmCitationMetadata(c.CitationMetadata);
        }

        public PalmChatMessage(string content, string? author) 
        { 
            this.Author = author;
            this.Content = content;
        }

        /// <summary>
        /// Optional. The author of this Message.
        ///
        /// This serves as a key for tagging
        /// the content of this Message when it is fed to the model as text.
        ///
        /// The author can be any alphanumeric string.
        /// </summary>
        public string? Author { get; private set; }

        /// <summary>
        /// Required. The text content of the structured `Message`.
        /// </summary>
        public string Content { get; private set; } = string.Empty;

        /// <summary>
        /// Output only. Citation information for model-generated `content` in this
        /// `Message`.
        /// </summary>
        public PalmCitationMetadata? CitationMetadata { get; private set; }
    }
}
