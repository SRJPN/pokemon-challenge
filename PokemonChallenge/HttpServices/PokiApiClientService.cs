using PokeApiNet;

namespace PokemonChallenge.HttpServices
{
    public class PokiApiClientService : IPokeApiService
    {
        private readonly IApiConfiguration configuration;
        private readonly IPokiApiClient pokiApiClient;

        public PokiApiClientService(IPokiApiClient pokiApiClient, IApiConfiguration apiConfiguration)
        {
            this.pokiApiClient = pokiApiClient;
            this.configuration = apiConfiguration;
        }

        public async Task<string> GetDescriptionAsync(string pokemonName)
        {
            var pokemonSpecies = await pokiApiClient.GetResourceAsync<PokemonSpecies>(pokemonName);
            return pokemonSpecies.FlavorTextEntries.First(x => x.Language.Name == configuration.Locale).FlavorText;
        }

        public async Task<string> GetPokemonSpriteAsync(string pokemonName)
        {
            var pokemon = await pokiApiClient.GetResourceAsync<Pokemon>(pokemonName);
            return pokemon.Sprites.FrontDefault;
        }
    }
}