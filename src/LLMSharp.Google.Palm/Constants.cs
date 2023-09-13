namespace LLMSharp.Google.Palm
{
    /// <summary>
    /// Google Palm SDK constants
    /// </summary>
    internal sealed class Constants
    {
        public const string PalmApiKeyEnvVar = "GOOGLE_API_KEY";
        public const string GrpcClientHeaderForApiKey = "x-goog-api-key";
        public const string PalmDotnetSdkUserAgent = "llmsharp-google-palm-client-sdk";
        public const string DefaultPalmTextCompletionModel = "models/text-bison-001";
        public const string DefaultPalmChatCompletionModel = "models/chat-bison-001";
        public const string DefaultEmbeddingModel = "models/embedding-gecko-001";
        public const string RpcExceptionMessage = "Rpc Exception occured with Status:{0}. Details: {1}";
    }
}
