namespace PokemonChallenge.Models
{
    public class PokemonDescriptionResponse
    {
        public IEnumerable<FlavorTextResponse> FlavorTextEntries { get; set; }
    }

    public class FlavorTextResponse
    {
        public string FlavorText { get; set; }
        public LanguageResponse Language { get; set; }
    }

    public class LanguageResponse
    {
        public string Language { get; set; }
    }
}