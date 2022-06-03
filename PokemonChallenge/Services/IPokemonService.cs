using PokemonChallenge.Models;

namespace PokemonChallenge.Services
{
    public interface IPokemonService
    {
        Task<Pokemon> GetPokemonAsync(string pokemonName);
    }
}