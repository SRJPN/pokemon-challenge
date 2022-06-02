namespace PokemonChallenge.Models
{
    public class SharespereTranslationResponse
    {
        public SharespereTranslationResponseContents Contents { get; set; }
    }

    public class SharespereTranslationResponseContents
    {
        public string Translated { get; set; }
    }
}