using gav = Google.Ai.Generativelanguage.V1Beta2;

namespace LLMSharp.Google.Palm.Common
{
    /// <summary>
    /// A citation to a source for a portion of a specific response.
    /// </summary>
    public class PalmCitationSource
    {
        internal PalmCitationSource(gav::CitationSource cs)
        {
            if (cs == null) return;

            this.StartIndex = cs.StartIndex;
            this.EndIndex = cs.EndIndex;
            this.Url = cs.Uri;
            this.License = cs.License;
        }

        /// <summary>
        /// Start of segment of the response that is attributed to this source.
        /// Index indicates the start of the segment, measured in bytes.
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// End of the attributed segment, exclusive.
        /// </summary>
        public int EndIndex { get; set; }

        /// <summary>
        /// URI that is attributed as a source for a portion of the text.
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// License for the GitHub project that is attributed as a source for segment.
        /// License info is required for code citations.
        /// </summary>
        public string? License { get; set; }
    }
}
