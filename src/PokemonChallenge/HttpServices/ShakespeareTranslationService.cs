using PokemonChallenge.Models;

namespace PokemonChallenge.HttpServices
{
    public class ShakespeareTranslationService : ITranslationService
    {
        private readonly IHttpClient httpClient;
        private readonly IApiConfiguration configuration;
        public ShakespeareTranslationService(IHttpClient httpClient, IApiConfiguration apiConfiguration)
        {
            this.httpClient = httpClient;
            this.configuration = apiConfiguration;
        }

        public async Task<string> GetTranslationAsync(string description)
        {
            var url = configuration.ShakespeareTranslationApiUrl;
            var body = new ShakespeareTranslationRequest() { Text = description };
            var response = await httpClient.PostAsync<ShakespeareTranslationRequest, SharespereTranslationResponse>(url, body);
            return response.Contents.Translated;
        }
    }
}