using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplesJustica.Application.Helpers;
using SimplesJustica.Application.Models;

namespace SimplesJustica.Application.Interfaces
{
    public interface IAutorAppService : IDisposable
    {
        BaseResponse Response { get; }
        Task<List<AutorModel>> List();
        Task<AutorModel> Get(Guid id);
        Task<AutorModel> Add(AutorModel entity);
        Task Update(AutorModel entity);
        AutorModel Delete(AutorModel entity);
    }
}
