namespace PokemonChallenge.HttpServices
{
    public interface ITranslationService
    {
        Task<string> GetTranslationAsync(string description);
    }
}