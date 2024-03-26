using System.Net;
using System.Net.Http;

namespace RandomUserAPI.Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetRandomUser_ReturnsOkResult()
        {

            // Arrange
            var httpClient = new HttpClient();

            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5066/api/User");
            request.Headers.Add("username", "testuser");
            request.Headers.Add("password", "testpassword");

            //var response = await client.GetAsync("http://localhost:5066/api/User");
            var response = await httpClient.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetRandomUserNoCredeintialInput_ReturnsBadRequestResult()
        {

            // Arrange
            var httpClient = new HttpClient();

            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5066/api/User");
            
            var response = await httpClient.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetRandomUserInvalidCredientialInput_ReturnsUnauthorizedRequestResult()
        {

            // Arrange
            var httpClient = new HttpClient();

            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5066/api/User");
            request.Headers.Add("username", "invalid user");
            request.Headers.Add("password", "invalid password");
            var response = await httpClient.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}