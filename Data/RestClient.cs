using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HighfieldTest.Data
{
    public class RestClient : IRestClient
    {
        private readonly ILogger<RestClient> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client;
        public RestClient(ILogger<RestClient> logger,
                         IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient();
        }

        public async Task<TResponse> GetAsync<TResponse>(string uri)
        {
            try
            {
                TResponse result;
                var uriObj = new Uri(uri);

                using (var response = await _client.GetAsync(uriObj))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        //Do something
                    }

                    using (var content = response.Content)
                    {
                        var contentType = content.Headers.ContentType.MediaType;

                        result = (contentType.ToLower()) switch
                        {
                            "application/json" => JsonConvert.DeserializeObject<TResponse>(await content.ReadAsStringAsync()),
                            _ => throw new InvalidOperationException($"Content type {contentType} is not supported!"),
                        };
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task PostNoResponseAsync<TRequest>(string uri, TRequest request)
        {
            try
            {
                var uriObj = new Uri(uri);

                var jsonContent = request == null ? "{}" : JsonConvert.SerializeObject(request);

                var body = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                using (var response = await _client.PostAsync(uriObj, body))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        //Do something
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
