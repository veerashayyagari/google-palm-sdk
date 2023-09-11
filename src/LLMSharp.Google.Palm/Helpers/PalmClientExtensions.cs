using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using gax = Google.Api.Gax;

namespace LLMSharp.Google.Palm.Helpers
{
    /// <summary>
    /// Helper extensions for Palm Client configurations
    /// </summary>
    internal static class PalmClientExtensions
    {
        /// <summary>
        /// Configures a given client builder
        /// </summary>
        /// <typeparam name="T">type of the client builder</typeparam>
        /// <typeparam name="TClient">type of the client</typeparam>
        /// <param name="builder">the client builder used for building TClient</param>
        /// <param name="clientOptions">ClientOptions for configuring the client</param>
        /// <returns>The client builder configured with clientOptions</returns>
        internal static T ConfigureBuilder<T, TClient>(this T builder, ClientOptions clientOptions) where T : gax::Grpc.ClientBuilderBase<TClient>
        {
            if (!string.IsNullOrEmpty(clientOptions.Endpoint))
            {
                builder.Endpoint = clientOptions.Endpoint;
            }

            if (clientOptions.GoogleCredential != null)
            {
                if (!string.IsNullOrEmpty(clientOptions.QuotaProject))
                {
                    builder.QuotaProject = clientOptions.QuotaProject;
                }

                if (clientOptions.Scopes != null)
                {
                    builder.Scopes = clientOptions.Scopes;
                }

                builder.GoogleCredential = clientOptions.GoogleCredential;
            }
            else
            {
                builder.ChannelCredentials = ChannelCredentials.SecureSsl;
            }

            builder.UserAgent = Constants.PalmDotnetSdkUserAgent;
            if (!string.IsNullOrEmpty(clientOptions.UserAgent))
            {
                builder.UserAgent = $"{builder.UserAgent};{clientOptions.UserAgent}";
            }

            builder.Logger = clientOptions.Logger ??
                LoggerFactory.Create(logging => logging.AddConsole()).CreateLogger("LLMSharp.Google.Palm.Client");

            return builder;
        }

        /// <summary>
        /// Configures settings with client options
        /// </summary>
        /// <typeparam name="T">type of service settings</typeparam>
        /// <param name="settings">settings to configure</param>
        /// <param name="clientOptions">clientOptions used for configuration</param>
        /// <returns>configured settings</returns>
        internal static T ConfigureServiceSettings<T>(this T settings, ClientOptions clientOptions) where T : gax::Grpc.ServiceSettingsBase
        {
            gax::Expiration exp = clientOptions.Timeout.HasValue ? gax::Expiration.FromTimeout(clientOptions.Timeout.Value) : gax::Expiration.None;
            settings.CallSettings = new gax::Grpc.CallSettings(null, exp, null, ConstructMutateHeaderAction(clientOptions), null, null);
            return settings;
        }

        /// <summary>
        /// Action that updates metadata for the GrpcClient using ClientOptions
        /// Adds apikey and/or any custom headers if present.
        /// </summary>
        /// <param name="clientOptions">ClientOptions used for configuration</param>
        /// <returns>Action that updates metadata</returns>
        private static Action<Metadata>? ConstructMutateHeaderAction(ClientOptions clientOptions)
        {
            if (string.IsNullOrEmpty(clientOptions.ApiKey))
            {
                if (clientOptions.CustomHeaders == null)
                {
                    return null;
                }
            }

            void headerMutate(Metadata m)
            {
                if (!string.IsNullOrEmpty(clientOptions.ApiKey))
                {
                    m.Add(Constants.GrpcClientHeaderForApiKey, clientOptions.ApiKey);
                }

                if(clientOptions.CustomHeaders != null)
                {
                    foreach(var header in clientOptions.CustomHeaders)
                    {                        
                        m.Add(header.Key, header.Value);
                    }
                }
            }

            return headerMutate;
        }
    }
}
