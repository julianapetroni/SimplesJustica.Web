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
    public class AutorAppService : IAutorAppService
    {
        private readonly IUnitOfWork unitOfWork;
        private BaseResponse _response;
        public BaseResponse Response
        {
            get => _response;
        }

        public AutorAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _response = new BaseResponse();
        }

        public async Task<List<AutorModel>> List()
        {
            return Mapper.Map<List<AutorModel>>(await unitOfWork.Autores.List());
        }

        public async Task<AutorModel> Get(Guid id)
        {
            return Mapper.Map<AutorModel>(await unitOfWork.Autores.Get(id));
        }

        public async Task<AutorModel> Add(AutorModel user, Guid id)
        {
            var Autor = Mapper.Map<Autor>(user);
            var add = unitOfWork.Autores.Add(Autor, id);

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                if (AutorExists(Autor.Id))
                {
                    Response.StatusCode = StatusCode.Conflict;
                    Response.Successful = false;
                    Response.ErroMessages.Add("Não foi possível adicionar um novo Autor ao sistema"); //TODO mudar pra um arquivo de resources
                }
                else
                {
                    //TODO Log de erro
                    Debug.Write(e.Message);
                }
            }

            return Mapper.Map<AutorModel>(add);
        }

        public async Task Update(AutorModel entity)
        {
            var Autor = Mapper.Map<Autor>(entity);
            unitOfWork.Autores.Update(Autor);

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch
            {
                if (!AutorExists(entity.Id))
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

        public AutorModel Delete(AutorModel entity)
        {
            var Autor = Mapper.Map<Autor>(entity);
            var delete = unitOfWork.Autores.Delete(Autor);
            unitOfWork.CommitAsync();
            return Mapper.Map<AutorModel>(delete);
        }

        public void Dispose()
        {
            _response = null;
            unitOfWork.Dispose();
        }

        private bool AutorExists(Guid id)
        {
            return unitOfWork.Autores.Find(e => e.Id == id).Any();
        }
    }
}
