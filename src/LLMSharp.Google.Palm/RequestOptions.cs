using System;
using System.Collections.Generic;

namespace LLMSharp.Google.Palm
{
    /// <summary>
    /// Request specific options that override any client specific options
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// Any custom headers specific to the request,
        /// Request headers will be added to request in addition to CustomHeaders set in ClientOptions
        /// </summary>
        public IDictionary<string, string>? RequestHeaders { get; set; }

        /// <summary>
        /// The maximum number of times that the client will retry a request in case of a
        /// temporary failure, like a network error or a 5XX error from the server.        
        /// Default : 0
        /// </summary>
        public int? MaxRetries { get; set; }

        /// <summary>
        /// Timeout for the grpc call. If null, no timeout is applied.
        /// If set, this will override any timeout set in ClientOptions.
        /// </summary>
        public TimeSpan? Timeout { get; set; }
    }
}
