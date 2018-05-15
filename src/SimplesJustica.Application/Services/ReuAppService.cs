using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using SimplesJustica.Application.Interfaces;
using SimplesJustica.Application.Models;
using SimplesJustica.Domain.Interfaces.UnitOfWork;

namespace SimplesJustica.Application.Services
{
    public class ReuAppService : IReuAppService
    {
        private readonly IUnitOfWork unitOfWork;

        public ReuAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<IdentificacaoBasicaModel>> List()
        {
            var model = new List<IdentificacaoBasicaModel>();
            Mapper.Map(await unitOfWork.Empresas.List(), model);
            
            return model;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
