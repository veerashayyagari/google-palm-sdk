using Google.Api.Gax.Grpc;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
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
            settings.CallSettings = new gax::Grpc.CallSettings(null, exp, null, ConstructMutateHeaderAction(clientOptions.ApiKey, clientOptions.CustomHeaders), null, null);
            return settings;
        }

        /// <summary>
        /// Custom request call settings using the provided request options
        /// </summary>
        /// <param name="reqOptions">Request option settings</param>
        /// <param name="token">Token for canceling the call</param>
        /// <returns>Customized call settings</returns>
        internal static gax::Grpc.CallSettings? GetCallSettings(this RequestOptions? reqOptions, CancellationToken? token)
        {
            if (reqOptions == null) return null;

            gax::Expiration exp = reqOptions.Timeout.HasValue ? gax::Expiration.FromTimeout(reqOptions.Timeout.Value) : gax::Expiration.None;
            Action<Metadata>? mutateAction = ConstructMutateHeaderAction(null, reqOptions.RequestHeaders);
            RetrySettings? retrySettings = null;

            if (reqOptions.MaxRetries.HasValue)
            {
                static bool retryFilter(Exception ex)
                {
                    if (ex is RpcException)
                    {
                        var rex = ex as RpcException;
                        if (rex?.StatusCode == StatusCode.Internal || rex?.StatusCode == StatusCode.DeadlineExceeded)
                        {
                            return true;
                        }
                    }

                    return false;
                }

                retrySettings = gax::Grpc.RetrySettings.FromExponentialBackoff(
                    reqOptions.MaxRetries.Value,
                    TimeSpan.FromMilliseconds(200), TimeSpan.FromMilliseconds(1000), 2, retryFilter);
            }

            return new gax::Grpc.CallSettings(token, exp, retrySettings, mutateAction, null, null);
        }

        /// <summary>
        /// Action that updates metadata for the GrpcClient using ClientOptions
        /// Adds apikey and/or any custom headers if present.
        /// </summary>
        /// <param name="apiKey">apiKey to update if exists</param>
        /// <param name="customHeaders">customHeaders to update if they exist</param>
        /// <returns>Action that updates metadata</returns>
        private static Action<Metadata>? ConstructMutateHeaderAction(string? apiKey, IDictionary<string, string>? customHeaders)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                if (customHeaders == null)
                {
                    return null;
                }
            }

            void headerMutate(Metadata m)
            {
                if (!string.IsNullOrEmpty(apiKey))
                {
                    m.Add(Constants.GrpcClientHeaderForApiKey, apiKey);
                }

                if (customHeaders != null)
                {
                    foreach (var header in customHeaders)
                    {
                        m.Add(header.Key, header.Value);
                    }
                }
            }

            return headerMutate;
        }
    }
}
