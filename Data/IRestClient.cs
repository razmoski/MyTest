using System;
using System.Threading.Tasks;

namespace HighfieldTest.Data
{
    public interface IRestClient : IDisposable
    {
        Task<TResponse> GetAsync<TResponse>(string uri);
        Task PostNoResponseAsync<TRequest>(string uri, TRequest request);
    }
}
