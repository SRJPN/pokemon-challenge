using PokeApiNet;
using PokemonChallenge.HttpServices;

namespace PokemonChallenge.Test
{
    public class PokiApiClientServiceTests
    {
        private Mock<IPokiApiClient> clientMock;
        private Mock<IApiConfiguration> configurationMock;
        private IPokeApiService service;

        public PokiApiClientServiceTests()
        {
            clientMock = new Mock<IPokiApiClient>();
            configurationMock = new Mock<IApiConfiguration>();
            service = new PokiApiClientService(clientMock.Object, configurationMock.Object);
        }

        [Fact]
        public async void GetDescriptionAsync_ShouldGetDescriptionForPokemonName()
        {
            var descriptionResponse = new PokemonSpecies() { FlavorTextEntries = new List<PokemonSpeciesFlavorTexts>() { new PokemonSpeciesFlavorTexts() { FlavorText = "some-description", Language = new NamedApiResource<Language>() { Name = "en" } } } };
            configurationMock.Setup(x => x.PokemonDescriptionApiUrl).Returns("description-url");
            configurationMock.Setup(x => x.Locale).Returns("en");
            clientMock.Setup(x => x.GetResourceAsync<PokemonSpecies>(It.IsAny<string>())).ReturnsAsync(descriptionResponse);

            var result = await service.GetDescriptionAsync("pokemon-name");

            Assert.Equal("some-description", result);

            clientMock.Verify(x => x.GetResourceAsync<PokemonSpecies>("pokemon-name"));
        }

        [Fact]
        public async void GetPokemonSpriteAsync_ShouldGetSpriteForPokemonName()
        {
            var spriteResponse = new Pokemon();
            spriteResponse.Sprites = new PokemonSprites() { FrontDefault = "pokemon-sprite" };
            configurationMock.Setup(x => x.PokemonSpriteApiUrl).Returns("sprite-url");
            clientMock.Setup(x => x.GetResourceAsync<Pokemon>(It.IsAny<string>())).ReturnsAsync(spriteResponse);

            var result = await service.GetPokemonSpriteAsync("pokemon-name");

            Assert.Equal("pokemon-sprite", result);

            clientMock.Verify(x => x.GetResourceAsync<Pokemon>("pokemon-name"));
        }
    }
}