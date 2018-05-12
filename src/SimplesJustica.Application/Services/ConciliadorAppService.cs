using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SimplesJustica.Application.Helpers;
using SimplesJustica.Application.Interfaces;
using SimplesJustica.Application.Models;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.UnitOfWork;

namespace SimplesJustica.Application.Services
{
    public class ConciliadorAppService : IConciliadorAppService
    {
        private readonly IUnitOfWork unitOfWork;
        private BaseResponse _response;
        public BaseResponse Response
        {
            get => _response;
        }

        public ConciliadorAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _response = new BaseResponse();
        }

        public async Task<List<ConciliadorModel>> List()
        {
            return Mapper.Map<List<ConciliadorModel>>(await unitOfWork.Conciliadores.List());
        }

        public async Task<ConciliadorModel> Get(Guid id)
        {
            return Mapper.Map<ConciliadorModel>(await unitOfWork.Conciliadores.Get(id));
        }

        public async Task<ConciliadorModel> Add(ConciliadorModel entity)
        {
            var Conciliador = Mapper.Map<Conciliador>(entity);
            var add = unitOfWork.Conciliadores.Add(Conciliador);

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                if (ConciliadorExists(entity.Id))
                {
                    Response.StatusCode = StatusCode.Conflict;
                    Response.Successful = false;
                    Response.ErroMessages.Add("Não foi possível adicionar um novo Conciliador ao sistema"); //TODO mudar pra um arquivo de resources
                }
                else
                {
                    //TODO Log de erro
                    Debug.Write(e.Message);
                }
            }

            return Mapper.Map<ConciliadorModel>(add);
        }

        public async Task Update(ConciliadorModel entity)
        {
            var Conciliador = Mapper.Map<Conciliador>(entity);
            unitOfWork.Conciliadores.Update(Conciliador);

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch
            {
                if (!ConciliadorExists(entity.Id))
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

        public ConciliadorModel Delete(ConciliadorModel entity)
        {
            var Conciliador = Mapper.Map<Conciliador>(entity);
            var delete = unitOfWork.Conciliadores.Delete(Conciliador);
            unitOfWork.CommitAsync();
            return Mapper.Map<ConciliadorModel>(delete);
        }

        public void Dispose()
        {
            _response = null;
            unitOfWork.Dispose();
        }

        private bool ConciliadorExists(Guid id)
        {
            return unitOfWork.Conciliadores.Find(e => e.Id == id).Any();
        }
    }
}
