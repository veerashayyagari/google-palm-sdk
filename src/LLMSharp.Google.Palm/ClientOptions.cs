using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace LLMSharp.Google.Palm
{
    /// <summary>
    /// Google palm client configuration options
    /// </summary>
    public class ClientOptions
    {
        /// <summary>
        /// Google Palm ApiKey. Set either this property or GoogleCredentials, not both.
        /// Default: "GOOGLE_API_KEY" environment variable
        /// Set it to null if you do not want to use the environment variable and use either GoogleCredential or ApplicationDefaultCredential
        /// </summary>
        public string? ApiKey { get; set; } = Environment.GetEnvironmentVariable(Constants.PalmApiKeyEnvVar);

        /// <summary>
        /// [Optional] The grpc endpoint to connect to, or null to use the default endpoint "generativelanguage.googleapis.com:443".
        /// </summary>
        public string? Endpoint { get; set; }        

        /// <summary>
        /// [Optional] Custom headers to add for every client request being made to Palm endpoints.
        /// Leaving it null, will not add any custom headers.                 
        /// </summary>
        public IDictionary<string, string>? CustomHeaders { get; set; }

        /// <summary>
        /// [Optional] The logger to include in the client, or null to use the default console logger.
        /// </summary>
        public ILogger? Logger { get; set; }

        /// <summary>
        /// [Optional] The scopes to use, or null to use the default scopes.
        /// </summary>
        public IReadOnlyList<string>? Scopes { get; set; }

        /// <summary>
        /// [Optional] The GCP project ID that should be used for quota and billing purposes.        
        /// </summary>
        public string? QuotaProject { get; set; }

        /// <summary>
        /// [Optional] The credentials to use as a <see cref="GoogleCredential"/>, or null if credentials are being provided
        /// using <see cref="ApiKey"/>. Note that settings for <see cref="Scopes"/>, <see cref="QuotaProject"/> will be applied to this
        /// credential (creating a new one), in the same way as for application default credentials.
        /// </summary>
        public GoogleCredential? GoogleCredential { get; set; }

        /// <summary>
        /// [Optional] A custom user agent to specify in the channel metadata, or null if no custom user agent is required.
        /// A default user agent "llmsharp-google-palm-client-sdk" is added to all the requests, any custom user agent specified
        /// is appended to the default user agent.
        /// </summary>
        public string? UserAgent { get; set; }
    }
}
