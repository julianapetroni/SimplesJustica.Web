using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplesJustica.Application.Helpers;
using SimplesJustica.Application.Models;

namespace SimplesJustica.Application.Interfaces
{
    public interface IReclamacaoAppService
    {
        BaseResponse Response { get; }
        Task<List<ReclamacaoModel>> List();
        Task<ReclamacaoModel> Get(Guid id);
        Task<ReclamacaoModel> Add(ReclamacaoModel entity);
        Task Update(ReclamacaoModel entity);
        ReclamacaoModel Delete(ReclamacaoModel entity);
    }
}
