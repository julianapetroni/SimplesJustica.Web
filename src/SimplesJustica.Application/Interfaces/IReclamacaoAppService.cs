﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplesJustica.Application.Helpers;
using SimplesJustica.Application.Models;

namespace SimplesJustica.Application.Interfaces
{
    public interface IReclamacaoAppService : IDisposable
    {
        BaseResponse Response { get; }
        List<ReclamacaoModel> List(Guid id);
        Task<ReclamacaoModel> Get(Guid id);
        Task<ReclamacaoUpdateViewModel> GetForUpdate(Guid id);
        Task<ReclamacaoModel> Add(RegistrarReclamacaoViewModel entity, Guid autorId);
        Task Update(ReclamacaoUpdateViewModel entity);
        Task<ReclamacaoModel> Delete(ReclamacaoModel entity);
    }
}
