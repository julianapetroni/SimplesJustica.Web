using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplesJustica.Application.Helpers;
using SimplesJustica.Application.Models;

namespace SimplesJustica.Application.Interfaces
{
    public interface IAcusadoAppService : IDisposable
    {
        BaseResponse Response { get; }
        Task<List<AcusadoModel>> List();
        Task<AcusadoModel> Get(Guid id);
        Task<AcusadoModel> Add(AcusadoModel entity);
        Task Update(AcusadoModel entity);
        AcusadoModel Delete(AcusadoModel entity);
    }
}
