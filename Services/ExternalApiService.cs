using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Umbraco_Azure_test.Models;

namespace Umbraco_Azure_test.Services
{
    public class ExternalApiService : IExternalApiService
    {
        private readonly HttpClient _httpClient;

        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JokeModel> GetJokeAsync()
        {
            var response = await _httpClient.GetAsync("https://api.chucknorris.io/jokes/random");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var joke = JsonSerializer.Deserialize<JokeModel>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return joke;
        }
    }
}
