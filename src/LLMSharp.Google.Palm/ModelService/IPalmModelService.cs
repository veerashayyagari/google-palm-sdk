using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LLMSharp.Google.Palm
{
    public interface IPalmModelService
    {
        /// <summary>
        /// Gets the Palm Model for the given model name
        /// </summary>
        /// <param name="name">Palm Model name</param>
        /// <param name="reqOptions">Request specific options to configure</param>
        /// <param name="cancellationToken">Token to cancel the async fetch of model</param>
        /// <returns>Palm Model details</returns>
        public Task<PalmModel> GetModelAsync(string name, RequestOptions? reqOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// fetch available palm models by page
        /// </summary>
        /// <param name="pageSize">page size to fetch, default: 10</param>
        /// <param name="continuationToken">continuationToken to use for fetching subsequent pages</param>
        /// <param name="reqOptions">Request specific options to configure</param>
        /// <returns>Iterable enumeration of Palm Models and any continuation token to use for next page</returns>
        public (IEnumerable<PalmModel>, string?) ListModels(int pageSize = 10, string? continuationToken = null, RequestOptions? reqOptions = null);

        /// <summary>
        /// fetch a stream of available of palm models
        /// </summary>
        /// <param name="reqOptions">Request specific options to configure</param>
        /// <param name="cancellationToken">Token to cancel the async fetch of models</param>
        /// <returns>An AsyncEnumerable stream of palm models</returns>
        public IAsyncEnumerable<PalmModel> ListModelsAsync(RequestOptions? reqOptions = null, CancellationToken cancellationToken = default);
    }
}
