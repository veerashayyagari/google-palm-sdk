using Grpc.Core;
using LLMSharp.Google.Palm.Common;
using LLMSharp.Google.Palm.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using gav = Google.Ai.Generativelanguage.V1Beta2;

namespace LLMSharp.Google.Palm
{
    /// <summary>
    /// Implementation of Palm Model Service
    /// </summary>
    internal sealed class PalmModelService : IPalmModelService
    {           
        private readonly Lazy<gav::ModelServiceClient> _client = new(PalmClientFactory.GetModelServiceClient);

        /// <summary>
        /// Gets the Palm Model for the given model name
        /// </summary>
        /// <param name="name">Palm Model name</param>
        /// <param name="reqOptions">Request specific options to configure</param>
        /// <param name="cancellationToken">Token to cancel the async fetch of model</param>
        /// <returns>Palm Model details</returns>
        public async Task<PalmModel> GetModelAsync(string name, RequestOptions? reqOptions = null, CancellationToken cancellationToken = default)
        {
            try
            {
                var callSettings = reqOptions.GetCallSettings(cancellationToken);
                gav::Model model = await _client.Value.GetModelAsync(PalmModel.MakeModelName(name), callSettings).ConfigureAwait(false);
                return new PalmModel(model);
            }
            catch (RpcException ex)
            {
                throw new PalmClientException(Constants.RpcExceptionMessage, ex.InnerException, ex.Status.StatusCode, ex.Status.Detail);
            }
        }

        /// <summary>
        /// fetch available palm models by page
        /// </summary>
        /// <param name="pageSize">page size to fetch, default: 10</param>
        /// <param name="continuationToken">continuationToken to use for fetching subsequent pages</param>
        /// <param name="reqOptions">Request specific options to configure</param>
        /// <returns>Iterable enumeration of Palm Models and any continuation token to use for next page</returns>
        public (IEnumerable<PalmModel>, string?) ListModels(int pageSize = 10, string? continuationToken = null, RequestOptions? reqOptions = null)
        {
            try
            {
                var callSettings = reqOptions.GetCallSettings(default);
                var responses = _client.Value.ListModels(pageSize, continuationToken, callSettings).AsRawResponses();

                List<PalmModel> modelsList = new();
                string? pageToken = null;

                foreach (var response in responses)
                {
                    modelsList.AddRange(response.Models.Select(x => new PalmModel(x)));
                    pageToken = response.NextPageToken;

                    if (modelsList.Count == pageSize) break;
                }

                return (modelsList, pageToken);
            }
            catch (RpcException ex)
            {
                throw new PalmClientException(Constants.RpcExceptionMessage, ex.InnerException, ex.Status.StatusCode, ex.Status.Detail);
            }
        }

        /// <summary>
        /// fetch a stream of available of palm models
        /// </summary>
        /// <param name="reqOptions">Request specific options to configure</param>
        /// <param name="cancellationToken">Token to cancel the async fetch of models</param>
        /// <returns>An AsyncEnumerable stream of palm models</returns>
        public async IAsyncEnumerable<PalmModel> ListModelsAsync(RequestOptions? reqOptions = null,[EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            ConfiguredCancelableAsyncEnumerable<gav::Model> responses;

            try
            {
                var callSettings = reqOptions.GetCallSettings(cancellationToken);
                responses = _client.Value.ListModelsAsync(null, null, callSettings).ConfigureAwait(false);                
            }
            catch (RpcException ex)
            {
                throw new PalmClientException(Constants.RpcExceptionMessage, ex.InnerException, ex.Status.StatusCode, ex.Status.Detail);
            }

            await foreach (var response in responses)
            {
                yield return new PalmModel(response);
            }
        }        
    }
}
