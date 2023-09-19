using LLMSharp.Google.Palm.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LLMSharp.Google.Palm.Tests
{
    [TestClass]
    public class ModelTests
    {
        private readonly GooglePalmClient _client;

        public ModelTests()
        {
            _client = new GooglePalmClient();
        }

        [TestMethod]
        public async Task Getting_An_Existing_Palm_Model_Should_Succeed()
        {
            var model = await _client.GetModelAsync("chat-bison-001");
            Assert.IsNotNull(model);
            Assert.AreEqual("models/chat-bison-001", model.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(PalmClientException))]
        public async Task Getting_An_NonExisting_Palm_Model_Should_Throw()
        {
            var model = await _client.GetModelAsync("chat-b-0");
        }

        [TestMethod]
        public void Getting_Sync_List_Models_Should_Succeed()
        {
            var (models, pageToken) = _client.ListModels();
            Assert.IsNotNull(models);
            Assert.IsTrue(models.Any());
            Assert.IsTrue(string.IsNullOrEmpty(pageToken));
        }

        [TestMethod]
        public void Getting_Sync_List_Models_With_PageToken_Should_Succeed()
        {
            string? pageToken = null;
            IEnumerable<PalmModel> models;
            int counter = 0;
            do
            {
                (models, pageToken) = _client.ListModels(1, pageToken);
                Assert.IsNotNull(models);
                Assert.IsNotNull(models.Count() == 1);
                counter++;
            } while (!string.IsNullOrEmpty(pageToken));

            Assert.IsTrue(counter > 1);
        }

        [TestMethod]
        public async Task Getting_Async_List_Models_Should_Succeed()
        {
            var models = _client.ListModelsAsync();
            int counter = 0;
            await foreach(var model in models)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(model.Name));
                counter++;
            }

            Assert.IsTrue(counter > 1);
        }
    }
}
