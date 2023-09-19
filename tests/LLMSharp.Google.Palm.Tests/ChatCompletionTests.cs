using Google.Ai.Generativelanguage.V1Beta2;
using LLMSharp.Google.Palm.Common;
using LLMSharp.Google.Palm.DiscussService;

namespace LLMSharp.Google.Palm.Tests
{
    [TestClass]
    public class ChatCompletionTests
    {
        private readonly GooglePalmClient _client;

        public ChatCompletionTests()
        {
            _client = new GooglePalmClient();
        }

        [TestMethod]
        public async Task Should_Chat_Successfully_With_Simple_Message()
        {
            List<PalmChatMessage> messages = new()
            {
                new("hello bard!", "user"),
            };

            var response = await _client.ChatAsync(messages, null, null);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Candidates.Any());
            Assert.AreEqual(response.Candidates[0].Author, "1");
            Assert.IsFalse(string.IsNullOrEmpty(response.Candidates[0].Content));
        }

        [TestMethod]
        public async Task Should_Chat_Successfully_With_Simple_Message_And_Context()
        {
            List<PalmChatMessage> messages = new()
            {
                new("hello bard!", "user"),
            };
            string context = "Translate the phrase from English to French.";
            var response = await _client.ChatAsync(messages, context, null);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Candidates.Any());
            Assert.AreEqual(response.Candidates[0].Author, "1");
            Assert.IsFalse(string.IsNullOrEmpty(response.Candidates[0].Content));
        }

        [TestMethod]
        public async Task Should_Chat_Successfully_With_Message_Context_And_Examples()
        {
            List<PalmChatExample> examples = new()
            {
                new PalmChatExample
                {
                    Input = new("what is a large language model ? Can you explain in a single sentence ?", "0"),
                    Output = new("A large language model is a massive artificial intelligence model that can generate and understand human language.", "1")
                },
                new PalmChatExample
                {
                    Input = new("how does it understand human language ?", "0"),
                    Output = new("Large language models (LLMs) understand human language by learning statistical patterns in vast amounts of text data. This data can include books, articles, code, and even conversations. LLMs learn to predict which word or phrase is most likely to follow another, given the context of the surrounding text.", "1")
                }
            };

            List<PalmChatMessage> messages = new()
            {
                new("What is the conversation about? Who are the involved parties ?", "0"),
            };

            string context = "Given the examples of a conversation between a human and chatbot. Answer any further questions";
            var response = await _client.ChatAsync(messages, context, examples);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Candidates.Any());
            Assert.IsTrue(response.Candidates[0].Content.Contains("human"));
            Assert.IsTrue(response.Candidates[0].Content.Contains("chatbot"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task Should_Throw_On_Invalid_Temperature_ChatCompletionRequest()
        {
            List<PalmChatMessage> messages = new()
            {
                new("What is the conversation about? Who are the involved parties ?", "0"),
            };

            PalmChatCompletionRequest request = new()
            {
                Messages = messages,
                Temperature = 20,
            };

            var response = await _client.ChatAsync(request);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task Should_Throw_On_Invalid_TopP_ChatCompletionRequest()
        {

            List<PalmChatMessage> messages = new()
            {
                new("hello bard!", "user"),
            };

            PalmChatCompletionRequest request = new()
            {
                Messages = messages,
                Temperature = 0.8f,
                TopP = 20,
            };
            var response = await _client.ChatAsync(request);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task Should_Throw_On_Invalid_CandidateCount_ChatCompletionRequest()
        {
            List<PalmChatMessage> messages = new()
            {
                new("hello bard!", "user"),
            };

            PalmChatCompletionRequest request = new()
            {
                Messages = messages,
                Temperature = 0.8f,
                CandidateCount = 12
            };
            var response = await _client.ChatAsync(request);            
        }

        [TestMethod]       
        public async Task Should_Throw_On_Invalid_TopK_ChatCompletionRequest()
        {
            List<PalmChatMessage> messages = new()
            {
                new("hello bard!", "user"),
            };

            PalmChatCompletionRequest request = new()
            {
                Messages = messages,
                Temperature = 0.8f,
                TopK = 0
            };
            var response = await Assert.ThrowsExceptionAsync<PalmClientException>(() => _client.ChatAsync(request)).ConfigureAwait(false);   
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Message.Contains("InvalidArgument"));         
        }

        [TestMethod]
        public async Task Should_Chat_Successfully_With_AllParams_Chat_Completion_Req()
        {
            List<PalmChatExample> examples = new()
            {
                new PalmChatExample
                {
                    Input = new("what is a large language model ? Can you explain in a single sentence ?", "0"),
                    Output = new("A large language model is a massive artificial intelligence model that can generate and understand human language.", "1")
                },
                new PalmChatExample
                {
                    Input = new("how does it understand human language ?", "0"),
                    Output = new("Large language models (LLMs) understand human language by learning statistical patterns in vast amounts of text data. This data can include books, articles, code, and even conversations. LLMs learn to predict which word or phrase is most likely to follow another, given the context of the surrounding text.", "1")
                }
            };

            List<PalmChatMessage> messages = new()
            {
                new("What is the conversation about? Who are the involved parties ?", "0"),
            };

            string context = "Given the examples of a conversation between a human and chatbot. Answer any further questions";
            var response = await _client.ChatAsync(new PalmChatCompletionRequest
            {
                Messages = messages,
                Examples = examples,
                Context = context,
                Temperature = 0.8f,
                TopK = 40
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Candidates.Any());
            Assert.IsFalse(string.IsNullOrEmpty(response.Candidates[0].Content));            
        }

        [TestMethod]
        public async Task Should_Count_Tokens_Successfully()
        {
            List<PalmChatExample> examples = new()
            {
                new PalmChatExample
                {
                    Input = new("what is a large language model ? Can you explain in a single sentence ?", "0"),
                    Output = new("A large language model is a massive artificial intelligence model that can generate and understand human language.", "1")
                },
                new PalmChatExample
                {
                    Input = new("how does it understand human language ?", "0"),
                    Output = new("Large language models (LLMs) understand human language by learning statistical patterns in vast amounts of text data. This data can include books, articles, code, and even conversations. LLMs learn to predict which word or phrase is most likely to follow another, given the context of the surrounding text.", "1")
                }
            };

            List<PalmChatMessage> messages = new()
            {
                new("What is the conversation about? Who are the involved parties ?", "0"),
            };

            string context = "Given the examples of a conversation between a human and chatbot. Answer any further questions";

            var response = await _client.CountMessageTokensAsync(messages, examples, context);
            Assert.IsNotNull(response);
            Assert.IsTrue(response > 10);
        }

        [TestMethod]
        public async Task Should_Count_Tokens_Successfully_With_Only_Message()
        {            
            List<PalmChatMessage> messages = new()
            {
                new("What is the conversation about? Who are the involved parties ?", "0"),
            };            

            var response = await _client.CountMessageTokensAsync(messages);
            Assert.IsNotNull(response);
            Assert.IsTrue(response > 10);
        }
    }
}
