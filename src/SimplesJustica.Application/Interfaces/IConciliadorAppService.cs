using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplesJustica.Application.Helpers;
using SimplesJustica.Application.Models;

namespace SimplesJustica.Application.Interfaces
{
    public interface IConciliadorAppService : IDisposable
    {
        BaseResponse Response { get; }
        Task<List<ConciliadorModel>> List();
        Task<ConciliadorModel> Get(Guid id);
        Task<ConciliadorModel> Add(ConciliadorModel entity);
        Task Update(ConciliadorModel entity);
        ConciliadorModel Delete(ConciliadorModel entity);
    }
}
