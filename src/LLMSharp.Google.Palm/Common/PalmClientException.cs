using System;
using System.Globalization;
using Grpc.Core;

namespace LLMSharp.Google.Palm.Common
{
    /// <summary>
    /// Base exception class for representing Google Palm API exceptions
    /// </summary>
    public class PalmClientException : Exception
    {
        /// <summary>
        /// Grpc response status
        /// </summary>
        public Status Status { get; private set; }

        /// <summary>
        /// Palm Client Exception constructor
        /// </summary>
        /// <param name="status">Grpc response status</param>
        /// <param name="innerException">Any inner exception included</param>
        public PalmClientException(
            Status status, Exception? innerException = null)
            : base(string.Format(CultureInfo.CurrentCulture, Constants.RpcExceptionMessage, status.StatusCode, status.Detail), innerException)
        {
            this.Status = status;
        }        
    }
}
