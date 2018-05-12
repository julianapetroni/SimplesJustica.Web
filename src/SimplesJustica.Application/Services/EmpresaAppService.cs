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
    public class EmpresaAppService : IEmpresaAppService
    {
        private readonly IUnitOfWork unitOfWork;
        private BaseResponse _response;
        public BaseResponse Response
        {
            get => _response;
        }

        public EmpresaAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _response = new BaseResponse();
        }

        public async Task<List<EmpresaModel>> List()
        {
            return Mapper.Map<List<EmpresaModel>>(await unitOfWork.Empresas.List());
        }

        public async Task<EmpresaModel> Get(Guid id)
        {
            return Mapper.Map<EmpresaModel>(await unitOfWork.Empresas.Get(id));
        }

        public async Task<EmpresaModel> Add(EmpresaModel entity)
        {
            var Empresa = Mapper.Map<Empresa>(entity);
            var add = unitOfWork.Empresas.Add(Empresa);

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                if (EmpresaExists(entity.Id))
                {
                    Response.StatusCode = StatusCode.Conflict;
                    Response.Successful = false;
                    Response.ErroMessages.Add("Não foi possível adicionar uma nova Empresa ao sistema"); //TODO mudar pra um arquivo de resources
                }
                else
                {
                    //TODO Log de erro
                    Debug.Write(e.Message);
                }
            }

            return Mapper.Map<EmpresaModel>(add);
        }

        public async Task Update(EmpresaModel entity)
        {
            var Empresa = Mapper.Map<Empresa>(entity);
            unitOfWork.Empresas.Update(Empresa);

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch
            {
                if (!EmpresaExists(entity.Id))
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

        public EmpresaModel Delete(EmpresaModel entity)
        {
            var Empresa = Mapper.Map<Empresa>(entity);
            var delete = unitOfWork.Empresas.Delete(Empresa);
            unitOfWork.CommitAsync();
            return Mapper.Map<EmpresaModel>(delete);
        }

        public void Dispose()
        {
            _response = null;
            unitOfWork.Dispose();
        }

        private bool EmpresaExists(Guid id)
        {
            return unitOfWork.Empresas.Find(e => e.Id == id).Any();
        }
    }
}
