using Microsoft.AspNetCore.Mvc;
using PokemonChallenge.Services;

namespace PokemonChallenge.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService service;

    public PokemonController(IPokemonService service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("/pokemon/{pokemonName}")]
    public async Task<ObjectResult> GetPokemonAsync(string pokemonName)
    {
        var pokemon = await service.GetPokemonAsync(pokemonName);
        return new OkObjectResult(pokemon);
    }
}