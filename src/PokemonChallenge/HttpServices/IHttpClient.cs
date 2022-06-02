namespace PokemonChallenge.HttpServices
{
    public interface IHttpClient
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<R, T>(string url, R body);
    }
}