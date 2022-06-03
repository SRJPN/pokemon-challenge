using PokemonChallenge.Models;

namespace PokemonChallenge.HttpServices
{
    public class PokeApiService : IPokeApiService
    {
        private readonly IHttpClient httpClient;
        private readonly IApiConfiguration configuration;

        public PokeApiService(IHttpClient httpClient, IApiConfiguration apiConfiguration)
        {
            this.httpClient = httpClient;
            this.configuration = apiConfiguration;
        }

        public async Task<string> GetDescriptionAsync(string pokemonName)
        {
            var url = $"{configuration.PokemonDescriptionApiUrl}/{pokemonName}";
            var pokemonDescriptionResponse = await httpClient.GetAsync<PokemonDescriptionResponse>(url);
            
            var firstFlavorTextResponse = pokemonDescriptionResponse.FlavorTextEntries.Where(x => x.Language.Language == configuration.Locale).First();
            return firstFlavorTextResponse.FlavorText;
        }

        public async Task<string> GetPokemonSpriteAsync(string pokemonName)
        {
            var url = $"{configuration.PokemonSpriteApiUrl}/{pokemonName}";

            var pokemonSpriteResponse = await httpClient.GetAsync<PokemonSpriteResponse>(url);

            return pokemonSpriteResponse.Sprites.FrontDefault;
        }
    }
}