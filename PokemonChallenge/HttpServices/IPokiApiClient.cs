using PokeApiNet;

namespace PokemonChallenge.HttpServices
{
    public interface IPokiApiClient
    {
        Task<T> GetResourceAsync<T>(string name) where T : NamedApiResource;
    }
}