using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
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
            return await SendAsync<T>(requestMessage);
        }

        private async Task<T> SendAsync<T>(HttpRequestMessage requestMessage)
        {
            var httpResponse = await _httpClient.SendAsync(requestMessage);
            requestMessage.Headers.Host = "some-host";
            return await httpResponse.CreateFromResponseAsync<T>();
        }

        public async Task<T> PostAsync<R, T>(string url, R body)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            var json = JsonSerializer.Serialize(body, new JsonSerializerOptions(){ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return await SendAsync<T>(requestMessage);
        }
    }
}