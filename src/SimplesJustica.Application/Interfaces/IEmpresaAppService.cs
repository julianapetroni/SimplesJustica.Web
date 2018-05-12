using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplesJustica.Application.Helpers;
using SimplesJustica.Application.Models;

namespace SimplesJustica.Application.Interfaces
{
    public interface IEmpresaAppService : IDisposable
    {
        BaseResponse Response { get; }
        Task<List<EmpresaModel>> List();
        Task<EmpresaModel> Get(Guid id);
        Task<EmpresaModel> Add(EmpresaModel entity);
        Task Update(EmpresaModel entity);
        EmpresaModel Delete(EmpresaModel entity);
    }
}
