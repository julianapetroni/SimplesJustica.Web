using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplesJustica.Application.Helpers;
using SimplesJustica.Application.Models;
using SimplesJustica.Identity.Entities;

namespace SimplesJustica.Application.Interfaces
{
    public interface IAutorAppService : IDisposable
    {
        BaseResponse Response { get; }
        Task<List<AutorModel>> List();
        Task<AutorModel> Get(Guid id);
        Task<AutorModel> Add(AutorModel entity, Guid id);
        Task Update(AutorModel entity);
        AutorModel Delete(AutorModel entity);
    }
}
