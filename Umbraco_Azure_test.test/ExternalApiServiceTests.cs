using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Umbraco_Azure_test.Models;
using Umbraco_Azure_test.Services;
using Xunit;

public class ExternalApiServiceTests
{
    [Fact]
    public async Task GetJokeAsync_ReturnsJokeModel()
    {
        // Arrange: Prepare a fake JSON response as the external API would return
        var jokeJson = "{\"value\":\"Test joke\"}";

        // Arrange: Create a mock HttpMessageHandler to intercept HTTP calls
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            // Setup the protected SendAsync method to return our fake response
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK, // Simulate a successful response
                Content = new StringContent(jokeJson), // Provide the fake JSON content
            });

        // Arrange: Create an HttpClient using the mocked handler
        var httpClient = new HttpClient(handlerMock.Object);

        // Arrange: Create the service instance with the mocked HttpClient
        var service = new ExternalApiService(httpClient);

        // Act: Call the method under test
        var result = await service.GetJokeAsync();

        // Assert: Check that the result is not null
        Assert.NotNull(result);

        // Assert: Check that the Value property matches the expected joke text
        Assert.Equal("Test joke", result.Value);
    }
}
