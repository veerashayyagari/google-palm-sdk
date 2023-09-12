using System;
using System.Globalization;

namespace LLMSharp.Google.Palm.Common
{
    /// <summary>
    /// Base exception class for representing Google Palm API exceptions
    /// </summary>
    public class PalmClientException : Exception
    {
        public PalmClientException(string message, params object[] args) :
            base(string.Format(CultureInfo.CurrentCulture, message, args))
        { }
    }
}
