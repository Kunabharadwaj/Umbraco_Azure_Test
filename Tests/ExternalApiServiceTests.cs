using Xunit;
using Moq;
using Umbraco_Azure_test.Services;
using Umbraco_Azure_test.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umbraco_Azure_test.Tests
{
    public class ExternalApiServiceTests
    {
        [Fact]
        public async Task ExternalApiService_Should_Return_Data()
        {
            // Arrange
            var httpClient = new HttpClient();
            var service = new ExternalApiService(httpClient);

            // Act
            var result = await service.GetJokeAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value); // Changed from Setup to Value
            Assert.NotEmpty(result.Value); // Changed from Setup to Value
        }

        [Fact]
        public void JokeModel_Should_Have_Properties()
        {
            // Arrange & Act
            var joke = new JokeModel
            {
                Value = "Test joke value" // Changed from Setup/Punchline to Value
            };

            // Assert
            Assert.Equal("Test joke value", joke.Value); // Testing the Value property
        }
    }
}