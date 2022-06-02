namespace PokemonChallenge;

public class ApiConfiguration : IApiConfiguration
{
    public string PokemonApiUrl { get; set; }

    public string ShakespeareTranslationApiUrl { get; set; }

    public string PokemonDescriptionApiUrl => $"{PokemonApiUrl}/pokemon-species";

    public string PokemonSpriteApiUrl => $"{PokemonApiUrl}/pokemon";

    public string Locale { get; set; }
}