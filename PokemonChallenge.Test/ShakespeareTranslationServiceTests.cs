using PokemonChallenge.HttpServices;
using PokemonChallenge.Models;

namespace PokemonChallenge.Test
{
    public class ShakespeareTranslationServiceTests
    {
        private Mock<IHttpClient> httpClientMock;
        private Mock<IApiConfiguration> configurationMock;
        private ShakespeareTranslationService service;

        public ShakespeareTranslationServiceTests()
        {
            httpClientMock = new Mock<IHttpClient>();
            configurationMock = new Mock<IApiConfiguration>();
            service = new ShakespeareTranslationService(httpClientMock.Object, configurationMock.Object);
        }
        [Fact]
        public async Task GetTranslationAsync_ShouldReturnTranslationFromShakespeareApiAsync()
        {
            var translationResponse = new SharespereTranslationResponse();
            translationResponse.Contents = new SharespereTranslationResponseContents() { Translated = "translated-description" };
            configurationMock.Setup(x => x.ShakespeareTranslationApiUrl).Returns("translation-url");
            httpClientMock.Setup(x => x.PostAsync<ShakespeareTranslationRequest, SharespereTranslationResponse>(It.IsAny<string>(), It.IsAny<ShakespeareTranslationRequest>())).ReturnsAsync(translationResponse);

            var result = await service.GetTranslationAsync("pokemon-description");

            Assert.Equal("translated-description", result);

            httpClientMock.Verify(x => x.PostAsync<ShakespeareTranslationRequest, SharespereTranslationResponse>("translation-url", It.Is<ShakespeareTranslationRequest>(r => r.Text == "pokemon-description")));
        }
    }
}