using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using SimplesJustica.Application.Helpers;
using SimplesJustica.Application.Interfaces;
using SimplesJustica.Application.Models;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.UnitOfWork;

namespace SimplesJustica.Application.Services
{
    public class AcusadoAppService : IAcusadoAppService
    {
        private readonly IUnitOfWork unitOfWork;
        private BaseResponse _response;
        public BaseResponse Response
        {
            get => _response;
        }

        public AcusadoAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _response = new BaseResponse();
        }

        public async Task<List<AcusadoModel>> List()
        {
            return Mapper.Map<List<AcusadoModel>>(await unitOfWork.Acusados.List());
        }

        public async Task<AcusadoModel> Get(Guid id)
        {
            return Mapper.Map<AcusadoModel>(await unitOfWork.Acusados.Get(id));
        }

        public async Task<AcusadoModel> Add(AcusadoModel entity)
        {
            var acusado = Mapper.Map<Acusado>(entity);
            var add = unitOfWork.Acusados.Add(acusado);

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch
            {
                if (AcusadoExists(entity.Id))
                {
                    Response.StatusCode = StatusCode.Conflict;
                    Response.Successful = false;
                    Response.ErroMessages.Add("Não foi possível adicionar um novo Acusado ao sistema"); //TODO mudar pra um arquivo de resources
                }
                else
                {
                    //TODO Log de erro
                }
            }

            return Mapper.Map<AcusadoModel>(add);
        }

        public async Task Update(AcusadoModel entity)
        {
            var acusado = Mapper.Map<Acusado>(entity);
            unitOfWork.Acusados.Update(acusado);

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch
            {
                if (!AcusadoExists(entity.Id))
                {
                    _response.StatusCode = StatusCode.NotFound;
                    _response.Successful = false;
                    _response.ErroMessages.Add("Registro não encontrado"); //TODO mudar pra um arquivo de resources
                }
                else
                {
                    //TODO Log de erro
                }
            }
        }
      
        public AcusadoModel Delete(AcusadoModel entity)
        {
            var acusado = Mapper.Map<Acusado>(entity);
            var delete = unitOfWork.Acusados.Delete(acusado);
            unitOfWork.CommitAsync();
            return Mapper.Map<AcusadoModel>(delete);
        }

        public void Dispose()
        {
            _response = null;
            unitOfWork.Dispose();
        }

        private bool AcusadoExists(Guid id)
        {
            return unitOfWork.Acusados.Find(e => e.Id == id).Any();
        }
    }
}
