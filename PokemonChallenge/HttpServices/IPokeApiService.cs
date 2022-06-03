namespace PokemonChallenge.HttpServices
{
    public interface IPokeApiService
    {
        Task<string> GetDescriptionAsync(string pokemonName);
        Task<string> GetPokemonSpriteAsync(string pokemonName);
    }
}