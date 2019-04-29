using System.Threading.Tasks;
using Htp.Validation.Domain.Contracts;
using Htp.Validation.Domain.Contracts.Models;
using Newtonsoft.Json;
using Xunit;

namespace Htp.Validation.Api.Tests
{
    public class BasicTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        public BasicTests(CustomWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [InlineData("/api/payments")]
        [InlineData("/api/payments/1")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = factory.CreateClient();

            // Act

            // The endpoint or route of the controller action.
            var response = await client.GetAsync(url);

            // Assert
            // Must be successful.
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task CanGetPlayers()
        {
            // Arrange
            var client = factory.CreateClient();

            // Act
            // The endpoint or route of the controller action.
            var response = await client.GetAsync("/api/payments");

            // Assert
            // Must be successful.
            response.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var jsonString = await response.Content.ReadAsStringAsync();
            var wrapper = JsonConvert.DeserializeObject<LinkedCollectionResourceWrapper<PaymentModel>>(jsonString);
            var payments = wrapper.Value;

            Assert.Contains(payments, p => p.FirstName == "1 - First name");
            Assert.Contains(payments, p => p.FirstName == "2 - First name");
        }
    }
}
