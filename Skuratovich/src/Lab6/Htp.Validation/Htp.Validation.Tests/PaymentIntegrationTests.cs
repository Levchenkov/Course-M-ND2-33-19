using System.Net;
using System.Net.Http;
using Htp.Validation.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Htp.Validation.Tests
{
    [TestClass]
    public class PaymentIntegrationTests
    {
        private readonly HttpClient client;

        public PaymentIntegrationTests()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            client = server.CreateClient();
        }

        [TestMethod]
        public void PaymentGetAllTest()
        {
            //Arange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/api/payments");

            //Act
            var response = client.SendAsync(request).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        [DataRow(100)]
        public void PaymentGetOneTest(int id)
        {
            //Arange
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"/api/payments/{id}");

            //Act
            var response = client.SendAsync(request).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
