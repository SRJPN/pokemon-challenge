using PokemonChallenge.HttpServices;
using PokemonChallenge.Services;

namespace PokemonChallenge.Test
{
    public class PokemonServiceTests
    {
        private Mock<IPokeApiService> pokeApiMock;
        private Mock<ITranslationService> translationServiceMock;
        private IPokemonService service;

        public PokemonServiceTests()
        {
            pokeApiMock = new Mock<IPokeApiService>();
            translationServiceMock = new Mock<ITranslationService>();
            service = new PokemonService(pokeApiMock.Object, translationServiceMock.Object);
        }

        [Fact]
        public async void GetPokemon_ShouldReturnPokemonWithTranslatedDescriptionRetrivedFromService()
        {
            const string PokemonName = "pokemon-name";
            const string Description = "pokemon description";
            
            pokeApiMock.Setup(x => x.GetDescriptionAsync(It.IsAny<string>())).ReturnsAsync(Description);
            translationServiceMock.Setup(x => x.GetTranslationAsync(It.IsAny<string>())).ReturnsAsync(Description);

            var pokemon = await service.GetPokemonAsync(PokemonName);

            Assert.Equal(Description, pokemon.Description);

            pokeApiMock.Verify(x => x.GetDescriptionAsync(It.Is<string>(y => y == PokemonName)));
            translationServiceMock.Verify(x => x.GetTranslationAsync(It.Is<string>(y => y == Description)));
        }

        [Fact]
        public async Task GetPokemon_ShouldReturnPokemonWithSpriteRetrivedFromServiceAsync()
        {
            const string PokemonName = "pokemon-name";
            const string Sprite = "some-url";
            
            pokeApiMock.Setup(x => x.GetPokemonSpriteAsync(It.IsAny<string>())).ReturnsAsync(Sprite);

            var pokemon = await service.GetPokemonAsync(PokemonName);

            Assert.Equal(Sprite, pokemon.Sprite);

            pokeApiMock.Verify(x => x.GetPokemonSpriteAsync(It.Is<string>(y => y == PokemonName)));
        }
    }
}
