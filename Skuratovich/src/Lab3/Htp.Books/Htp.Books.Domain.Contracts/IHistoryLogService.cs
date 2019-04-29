using System.Collections.Generic;
using Htp.Books.Domain.Contracts.ViewModels;

namespace Htp.Books.Domain.Contracts
{
    public interface IHistoryLogService
    {
        HistoryLogViewModel Get(int id);
        IEnumerable<HistoryLogViewModel> GetAll();
    }
}
