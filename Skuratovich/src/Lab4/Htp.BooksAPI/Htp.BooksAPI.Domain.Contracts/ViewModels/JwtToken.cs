using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Htp.BooksAPI.Domain.Contracts.ViewModels
{
    public class JwtToken : IToken
    {
        public Task Initialization { get; private set; }
        public string Token { get; private set; }

        public JwtToken()
        {
            Initialization = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            var httpClient = new HttpClient();

            var clientModel = new ClientModel()
            {
                Username = "user",
                Password = "password"
            };

            var jsonString = JsonConvert.SerializeObject(clientModel);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"http://localhost:5002/api/auth/token", content);

            response.EnsureSuccessStatusCode();
            jsonString = await response.Content.ReadAsStringAsync();
            clientModel = JsonConvert.DeserializeObject<ClientModel>(jsonString);
            var token = clientModel.Token;

            Token = token;
        }
    }
}
