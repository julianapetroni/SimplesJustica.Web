using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SimplesJustica.Application.Interfaces;
using SimplesJustica.Application.Models;
using SimplesJustica.Data.UnitOfWork;

namespace SimplesJustica.Application.Services
{
    public class ReuAppService : IReuAppService
    {
        private readonly UnitOfWork unitOfWork;

        public ReuAppService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<IdentificacaoBasicaModel>> List()
        {
            var model = new List<IdentificacaoBasicaModel>();
            Mapper.Map(await unitOfWork.Acusados.List(), model);
            Mapper.Map(await unitOfWork.Empresas.List(), model);

            return model;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
