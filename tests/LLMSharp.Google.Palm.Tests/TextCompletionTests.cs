using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LLMSharp.Google.Palm.Tests
{
    [TestClass]
    public class TextCompletionTests
    {
        private readonly GooglePalmClient _client;

        public TextCompletionTests()
        {
            _client = new GooglePalmClient();
        }

        [TestMethod]
        public async Task Should_Successfully_Return_Embeddings_For_Text()
        {
            var embeddings = await _client.GenerateEmbeddingsAsync("hello world");
            Assert.IsNotNull(embeddings);
            Assert.AreEqual(768, embeddings.Count());
        }

        [TestMethod]
        public async Task Should_Successfully_Return_Completion_For_Prompt()
        {
            var response = await _client.GenerateTextAsync("hello text bison!");
            Assert.IsTrue(response.Candidates.Count() == 1);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result?.Output);
            Assert.IsTrue(response.Result?.SafetyRatings?.Any());
        }

        [TestMethod]
        public async Task Should_Throw_On_Invalid_Params_TextCompletionRequest()
        {
            PalmTextCompletionRequest request = new PalmTextCompletionRequest
            {
                Prompt = "hello world palm!",
                Temperature = 20,
            };
            var response = await _client.GenerateTextAsync(request);
            Assert.IsTrue(response.Candidates.Count() == 1);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result?.Output);
            Assert.IsTrue(response.Result?.SafetyRatings?.Any());
        }
    }
}
