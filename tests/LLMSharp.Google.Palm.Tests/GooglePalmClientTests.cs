using LLMSharp.Google.Palm.Common;

namespace LLMSharp.Google.Palm.Tests
{
    [TestClass]
    public class GooglePalmClientTests
    {
        [TestMethod]
        public async Task Should_Initialize_Timeout_With_Assigned_Value()
        {
            GooglePalmClient client = new();        
            string text = $"Explain an Large Language Model to a 5 year old";
            var response = await Assert.ThrowsExceptionAsync<PalmClientException>(() => client.GenerateTextAsync(
                text,
                new RequestOptions{ Timeout = TimeSpan.FromMilliseconds(1)}));
            
            Assert.AreEqual(response.Status.StatusCode, Grpc.Core.StatusCode.DeadlineExceeded);
        }

        [TestMethod]
        public void Should_Initialize_Client_With_Assigned_Endpoint()
        {
            GooglePalmClient client = new(new ClientOptions{ Endpoint = "google.com"});
            var response = Assert.ThrowsException<PalmClientException>(() => client.ListModels());
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status.StatusCode, Grpc.Core.StatusCode.Unimplemented);
        }

        [TestMethod]
        public void Should_Throw_When_Overriding_ApiKey_Header_With_CustomHeaders()
        {
            GooglePalmClient client = new(new ClientOptions 
            { 
                CustomHeaders = new Dictionary<string,string>()
                {
                    {"x-goog-api-key", "radomapikey"}
                }
            });

            var response = Assert.ThrowsException<PalmClientException>(() => client.ListModels());
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status.StatusCode, Grpc.Core.StatusCode.InvalidArgument);
        }
    }
}