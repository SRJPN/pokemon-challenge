using System.Diagnostics.CodeAnalysis;
using System.Text;
using Newtonsoft.Json;
using PokemonChallenge.Extensions;

namespace PokemonChallenge.HttpServices
{
    [ExcludeFromCodeCoverage]
    public class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient _httpClient;
        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var httpResponse = await _httpClient.SendAsync(requestMessage);
            return await httpResponse.CreateFromResponseAsync<T>();
        }

        public async Task<T> PostAsync<R, T>(string url, R body)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.SendAsync(requestMessage);
            return await httpResponse.CreateFromResponseAsync<T>();
        }
    }
}