using Microsoft.AspNetCore.Mvc;

namespace Umbraco_Azure_test.Controllers
{
    public class ExternalApiController : Controller // Inherit from Controller to use View()
    {
        private readonly HttpClient _httpClient;

        public ExternalApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Example: Fetch data from a public API
            var response = await _httpClient.GetAsync("https://api.chucknorris.io/jokes/random");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return View("ExternalApi", json); // Pass the JSON to the view
        }
    }
}
