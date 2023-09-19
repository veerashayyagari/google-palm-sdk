using gav = Google.Ai.Generativelanguage.V1Beta2;
using System.Collections.Generic;
using System.Linq;

namespace LLMSharp.Google.Palm.Common
{
    /// <summary>
    /// A collection of source attributions for a piece of content.
    /// </summary>
    public class PalmCitationMetadata
    {
        internal PalmCitationMetadata(gav::CitationMetadata citationMetadata)
        {
            if (citationMetadata == null) return;
            this.CitationSources = citationMetadata.CitationSources.Select(cs => new PalmCitationSource(cs));
        }

        /// <summary>
        /// Citations to sources for a specific response.
        /// </summary>
        public IEnumerable<PalmCitationSource> CitationSources { get; private set; } = Enumerable.Empty<PalmCitationSource>();
    }
}
