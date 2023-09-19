using LLMSharp.Google.Palm.Helpers;
using System;
using gav = Google.Ai.Generativelanguage.V1Beta2;


namespace LLMSharp.Google.Palm
{
    /// <summary>
    /// Factory class for creating Palm Clients for ModelService, TextService and DiscussService
    /// </summary>
    internal static class PalmClientFactory
    {
        private static Lazy<gav::ModelServiceClient>? _modelServiceClient;
        private static Lazy<gav::TextServiceClient>? _textServiceClient;
        private static Lazy<gav::DiscussServiceClient>? _discussServiceClient;

        public static void Initialize(ClientOptions clientOptions)
        {
            _modelServiceClient = new Lazy<gav::ModelServiceClient>(() => BuildModelServiceClient(clientOptions));
            _textServiceClient = new Lazy<gav::TextServiceClient>(() => BuildTextServiceClient(clientOptions));
            _discussServiceClient = new Lazy<gav::DiscussServiceClient>(() => BuildDiscussServiceClient(clientOptions));            
        }

        /// <summary>
        /// Lazily instantiates and creates a singleton instance for calling DiscussService
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Throws when called before initializing the PalmClientFactory</exception>
        internal static gav::DiscussServiceClient GetDiscussServiceClient()
        {
            if (_discussServiceClient == null)
            {
                throw new InvalidOperationException("PalmClientFactory.Initialize needs to be invoked before fetching client");
            }

            return _discussServiceClient.Value;
        }

        /// <summary>
        /// Lazily instantiates and creates a singleton instance for calling TextService
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Throws when called before initializing the PalmClientFactory</exception>
        internal static gav::TextServiceClient GetTextServiceClient()
        {
            if (_textServiceClient == null)
            {
                throw new InvalidOperationException("PalmClientFactory.Initialize needs to be invoked before fetching client");
            }

            return _textServiceClient.Value;
        }

        /// <summary>
        /// Lazily instantiates and creates a singleton instance for calling ModelService
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Throws when called before initializing the PalmClientFactory</exception>
        internal static gav::ModelServiceClient GetModelServiceClient()
        {
            if (_modelServiceClient == null)
            {
                throw new InvalidOperationException("PalmClientFactory.Initialize needs to be invoked before fetching client");
            }

            return _modelServiceClient.Value;
        }

        /// <summary>
        /// Configures DiscussService using the client options and creates an instance
        /// </summary>
        /// <param name="clientOptions">ClientOptions used for configuring the client</param>
        /// <returns>Configured Instance of discuss service client</returns>        
        private static gav::DiscussServiceClient BuildDiscussServiceClient(ClientOptions clientOptions)
        {
            gav::DiscussServiceClientBuilder builder = new();
            builder = builder.ConfigureBuilder<gav::DiscussServiceClientBuilder, gav::DiscussServiceClient>(clientOptions);
            builder.Settings = gav::DiscussServiceSettings
                .GetDefault()
                .ConfigureServiceSettings(clientOptions);
            return builder.Build();
        }

        /// <summary>
        /// Configures TextService using the client options and creates an instance
        /// </summary>
        /// <param name="clientOptions">ClientOptions used for configuring the client</param>
        /// <returns>Configured Instance of text service client</returns> 
        private static gav::TextServiceClient BuildTextServiceClient(ClientOptions clientOptions)
        {
            gav::TextServiceClientBuilder builder = new();
            builder = builder.ConfigureBuilder<gav::TextServiceClientBuilder, gav::TextServiceClient>(clientOptions);
            builder.Settings = gav::TextServiceSettings
                .GetDefault()
                .ConfigureServiceSettings(clientOptions);
            return builder.Build();
        }

        /// <summary>
        /// Configures ModelService using the client options and creates an instance
        /// </summary>
        /// <param name="clientOptions">ClientOptions used for configuring the client</param>
        /// <returns>Configured Instance of model service client</returns> 
        private static gav::ModelServiceClient BuildModelServiceClient(ClientOptions clientOptions)
        {
            gav::ModelServiceClientBuilder builder = new();
            builder = builder.ConfigureBuilder<gav::ModelServiceClientBuilder, gav::ModelServiceClient>(clientOptions);
            builder.Settings = gav::ModelServiceSettings
                .GetDefault()
                .ConfigureServiceSettings(clientOptions);
            return builder.Build();
        }
    }
}
