namespace PokemonChallenge
{
    public interface IApiConfiguration
    {
        string PokemonDescriptionApiUrl { get; }
        string PokemonSpriteApiUrl { get; }
        string Locale { get; }
    }
}