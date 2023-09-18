using System.ComponentModel;
using Google.Ai.Generativelanguage.V1Beta2;
using LLMSharp.Google.Palm.Common;
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task Should_Throw_On_Invalid_Temperature_TextCompletionRequest()
        {
            PalmTextCompletionRequest request = new()
            {
                Prompt = "hello world palm!",
                Temperature = 20,
            };
            var response = await _client.GenerateTextAsync(request);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task Should_Throw_On_Invalid_TopP_TextCompletionRequest()
        {
            PalmTextCompletionRequest request = new()
            {
                Prompt = "hello world palm!",
                Temperature = 0.8f,
                TopP = 20,
            };
            var response = await _client.GenerateTextAsync(request);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task Should_Throw_On_Invalid_CandidateCount_TextCompletionRequest()
        {
            PalmTextCompletionRequest request = new()
            {
                Prompt = "hello world palm!",
                Temperature = 0.8f,
                CandidateCount = 12
            };
            var response = await _client.GenerateTextAsync(request);            
        }

        [TestMethod]       
        public async Task Should_Throw_On_Invalid_TopK_TextCompletionRequest()
        {
            PalmTextCompletionRequest request = new()
            {
                Prompt = "hello world palm!",
                Temperature = 0.8f,
                TopK = 0
            };
            var response = await Assert.ThrowsExceptionAsync<PalmClientException>(() => _client.GenerateTextAsync(request)).ConfigureAwait(false);   
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Message.Contains("InvalidArgument"));         
        }

        [TestMethod]
        public async Task Should_Apply_Safety_Settings_TextCompletionRequest()
        {
            PalmTextCompletionRequest request = new()
            {
                Prompt = "Can you suggest me a prescription for headache?",
                Temperature = 0.8f,
                SafetySettings = new List<PalmSafetySetting> {
                    new(HarmCategory.Medical, SafetySetting.Types.HarmBlockThreshold.BlockLowAndAbove)
                }
            };
            
            var response = await _client.GenerateTextAsync(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Candidates.Count(), 1);
            Assert.IsTrue(response.Filters.Any());
            Assert.AreEqual(response.Filters.First().Reason, ContentFilter.Types.BlockedReason.Safety);
            Assert.IsTrue(response.SafetyFeedback.Any());
            Assert.AreEqual(response.SafetyFeedback.First().Rating!.Category, HarmCategory.Medical);
            Assert.AreEqual(response.SafetyFeedback.First().Rating!.Probability, SafetyRating.Types.HarmProbability.Low);
            Assert.AreEqual(response.SafetyFeedback.First().Setting!.Threshold, SafetySetting.Types.HarmBlockThreshold.BlockLowAndAbove);
            Assert.AreEqual(response.SafetyFeedback.First().Setting!.Category, HarmCategory.Medical);
        }

        [TestMethod]
        public async Task TextCompletion_Should_Succeed_With_All_Settings()
        {
            PalmTextCompletionRequest request = new()
            {
                Prompt = "Can you suggest me a prescription for headache?",
                Temperature = 0.8f,
                TopK = 40,
                CandidateCount = 2,
                MaxOutputTokens = 1024,                
                SafetySettings = new List<PalmSafetySetting> {
                    new(HarmCategory.Medical, SafetySetting.Types.HarmBlockThreshold.BlockNone)
                }
            };

            var response = await _client.GenerateTextAsync(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Candidates.Count(), 2);
            Assert.AreEqual(response.Candidates.First().Output, response.Result!.Output);
        }
    }
}
