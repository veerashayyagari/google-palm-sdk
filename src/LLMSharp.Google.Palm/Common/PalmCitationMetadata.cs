using System.Collections.Generic;

namespace LLMSharp.Google.Palm.Common
{
    /// <summary>
    /// A collection of source attributions for a piece of content.
    /// </summary>
    public class PalmCitationMetadata
    {
        /// <summary>
        /// Citations to sources for a specific response.
        /// </summary>
        public IEnumerable<PalmCitationSource> CitationSources { get; set; } = new List<PalmCitationSource>();
    }
}
