using System;
using System.Collections.Generic;
using System.Threading;
using gav = Google.Ai.Generativelanguage.V1Beta2;

namespace LLMSharp.Google.Palm
{
    internal class PalmModelService : IPalmModelService
    {           
        private readonly gav::ModelServiceClient _client = PalmClientFactory.GetModelServiceClient();

        public PalmModel GetModel(string name, RequestOptions? reqOptions = null)
        {            
            throw new NotImplementedException();
        }

        public (IEnumerable<PalmModel>, string?) ListModels(int pageSize = 10, string? continuationToken = null, RequestOptions? reqOptions = null)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<PalmModel> ListModelsAsync(RequestOptions? reqOptions = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
