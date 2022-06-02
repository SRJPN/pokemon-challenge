namespace PokemonChallenge.HttpServices
{
    public interface IHttpClient
    {
        Task<T> SendAsync<T>(HttpMethod get, string url);
    }
}