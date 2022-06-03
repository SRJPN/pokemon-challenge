using PokemonChallenge.HttpServices;
using PokemonChallenge.Models;

namespace PokemonChallenge.Test
{
    public class PokeApiServiceTests
    {
        private Mock<IHttpClient> httpClientMock;
        private Mock<IApiConfiguration> configurationMock;
        private PokeApiService service;

        public PokeApiServiceTests()
        {
            httpClientMock = new Mock<IHttpClient>();
            configurationMock = new Mock<IApiConfiguration>();
            service = new PokeApiService(httpClientMock.Object, configurationMock.Object);
        }

        [Fact]
        public async void GetDescriptionAsync_ShouldGetDescriptionForPokemonName()
        {
            var descriptionResponse = new PokemonDescriptionResponse();
            descriptionResponse.FlavorTextEntries = new List<FlavorTextResponse>{ new FlavorTextResponse(){ FlavorText = "some-description", Language = new LanguageResponse(){Language = "en"}}};
            configurationMock.Setup(x => x.PokemonDescriptionApiUrl).Returns("description-url");
            configurationMock.Setup(x => x.Locale).Returns("en");
            httpClientMock.Setup(x => x.GetAsync<PokemonDescriptionResponse>(It.IsAny<string>())).ReturnsAsync(descriptionResponse);

            var result = await service.GetDescriptionAsync("pokemon-name");

            Assert.Equal("some-description", result);

            httpClientMock.Verify(x => x.GetAsync<PokemonDescriptionResponse>("description-url/pokemon-name"));
        }

        [Fact]
        public async void GetPokemonSpriteAsync_ShouldGetSpriteForPokemonName()
        {
            var spriteResponse = new PokemonSpriteResponse();
            spriteResponse.Sprites = new SpriteResponse() {FrontDefault = "pokemon-sprite"};
            configurationMock.Setup(x => x.PokemonSpriteApiUrl).Returns("sprite-url");
            httpClientMock.Setup(x => x.GetAsync<PokemonSpriteResponse>(It.IsAny<string>())).ReturnsAsync(spriteResponse);

            var result = await service.GetPokemonSpriteAsync("pokemon-name");

            Assert.Equal("pokemon-sprite", result);

            httpClientMock.Verify(x => x.GetAsync<PokemonSpriteResponse>("sprite-url/pokemon-name"));
        }
    }
}