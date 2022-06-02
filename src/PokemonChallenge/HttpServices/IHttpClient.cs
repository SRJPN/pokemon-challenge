namespace PokemonChallenge.HttpServices
{
    public interface IHttpClient
    {
        Task<T> SendAsync<T>(HttpMethod get, string url);
        Task<T> PostAsync<R, T>(string url, R body);
    }
}