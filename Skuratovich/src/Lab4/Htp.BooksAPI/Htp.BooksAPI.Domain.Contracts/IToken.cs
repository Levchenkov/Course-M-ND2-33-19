using System.Threading.Tasks;

namespace Htp.BooksAPI.Domain.Contracts
{
    public interface IToken
    {
        Task Initialization { get; }
        string Token { get; }
    }
}
