using static Google.Ai.Generativelanguage.V1Beta2.ContentFilter.Types;

namespace LLMSharp.Google.Palm.Common
{
    /// <summary>
    /// Content filtering metadata associated with processing a single request.
    ///
    /// ContentFilter contains a reason and an optional supporting string. The reason
    /// may be unspecified.
    /// </summary>
    public class PalmContentFilter
    {
        /// <summary>
        /// The reason content was blocked during request processing.
        /// </summary>
        public BlockedReason Reason { get; set; }

        /// <summary>
        /// An optional string that describes the filtering behavior in more detail.
        /// </summary>
        public string? Message { get; set; }
    }
}
