using PokeApiNet;

namespace PokemonChallenge.HttpServices
{
    public class PokiApiClientWrapper : IPokiApiClient
    {
        private PokeApiClient pokeClient;

        public PokiApiClientWrapper()
        {
            pokeClient = new PokeApiClient();
        }

        public Task<T> GetResourceAsync<T>(string name) where T : NamedApiResource
        {
            return pokeClient.GetResourceAsync<T>(name);
        }
    }
}