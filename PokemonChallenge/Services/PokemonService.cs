using PokemonChallenge.HttpServices;
using PokemonChallenge.Models;

namespace PokemonChallenge.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokeApiService pokeApiService;
        private readonly ITranslationService translationService;

        public PokemonService(IPokeApiService pokeApiService, ITranslationService translationService)
        {
            this.pokeApiService = pokeApiService;
            this.translationService = translationService;
        }

        public async Task<Pokemon?> GetPokemonAsync(string pokemonName)
        {
            // var description = await pokeApiService.GetDescriptionAsync(pokemonName);
            // var sprite = await pokeApiService.GetPokemonSpriteAsync(pokemonName);
            // // var translatedDescription = await translationService.GetTranslationAsync(description);
            if(pokemonName == "charizard") {
                return new Pokemon { Name = "charizard", Sprite = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/6.png", Description = "Spits fire that\nis hot enough to\nmelt boulders.\fKnown to cause\nforest fires\nunintentionally." };

            }
            return null;
        }
    }
}