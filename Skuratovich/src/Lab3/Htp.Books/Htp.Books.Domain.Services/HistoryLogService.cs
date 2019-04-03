using System.Collections.Generic;
using AutoMapper;
using Htp.Books.Data.Contracts;
using Htp.Books.Data.Contracts.Entities;
using Htp.Books.Domain.Contracts;
using Htp.Books.Domain.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Htp.Books.Domain.Services
{
    public class HistoryLogService : IHistoryLogService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;


        public HistoryLogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public HistoryLogViewModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<HistoryLogViewModel> GetAll()
        {
            IEnumerable<HistoryLog> historyLogs = unitOfWork.GetAll<int, HistoryLog>();

            var result = mapper.Map<IEnumerable<HistoryLog>, IEnumerable<HistoryLogViewModel>>(historyLogs);
         
            return result;
        }
    }
}
