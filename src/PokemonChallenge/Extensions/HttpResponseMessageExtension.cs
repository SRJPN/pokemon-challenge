using Newtonsoft.Json;

namespace PokemonChallenge.Extensions
{
    public static class HttpResponseMessageExtension
    {
        public static async Task<T> CreateFromResponseAsync<T>(this HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            return default(T);
        }
    }
}