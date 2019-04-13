using System;
namespace Htp.BooksAPI.Domain.Contracts.ViewModels
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
