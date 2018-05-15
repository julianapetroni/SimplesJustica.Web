using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using SimplesJustica.Application.Models;

namespace SimplesJustica.Application.Interfaces
{
    public interface IReuAppService : IDisposable
    {
        Task<List<IdentificacaoBasicaModel>> List();
    }
}
