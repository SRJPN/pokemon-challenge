using Microsoft.AspNetCore.Mvc;
using PokemonChallenge.Controllers;
using PokemonChallenge.Models;
using PokemonChallenge.Services;

namespace PokemonChallenge.Test
{
    public class PokemonControllerTests
    {
        [Fact]
        public async void GetPokemonAsync_RetrivesPokemonForPokemonName()
        {
            var serviceMock = new Mock<IPokemonService>();

            serviceMock.Setup(x => x.GetPokemonAsync(It.IsAny<string>())).ReturnsAsync(new Pokemon());

            var controller = new PokemonController(serviceMock.Object);

            var objectResult = await controller.GetPokemonAsync("pokemon-name");

            Assert.IsType<OkObjectResult>(objectResult);
            serviceMock.Verify(x => x.GetPokemonAsync("pokemon-name"));
        }
    }
}