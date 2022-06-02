
using System.Text.Json;

namespace PokemonChallenge.Extensions
{
    public static class HttpResponseMessageExtension
    {
        public static async Task<T> CreateFromResponseAsync<T>(this HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            throw new Exception("Pokemon not found");
        }
    }
}