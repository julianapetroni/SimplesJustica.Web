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
using SimplesJustica.Domain.Enum;
using SimplesJustica.Domain.Interfaces.UnitOfWork;

namespace SimplesJustica.Application.Services
{
    public class ReclamacaoAppService : IReclamacaoAppService
    {
        private readonly IUnitOfWork unitOfWork;
        private BaseResponse _response;
        public BaseResponse Response
        {
            get => _response;
        }

        public ReclamacaoAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _response = new BaseResponse();
        }

        public List<ReclamacaoModel> List(Guid id)
        {
            var result = unitOfWork.Reclamacoes.Find(c => c.AutorId == id).ToList();
            return Mapper.Map<List<ReclamacaoModel>>(result);
        }

        public async Task<ReclamacaoModel> Get(Guid id)
        {
            return Mapper.Map<ReclamacaoModel>(await unitOfWork.Reclamacoes.Get(id));
        }

        public async Task<ReclamacaoModel> Add(RegistrarReclamacaoViewModel model, Guid autorId)
        {
            var reclamacao = Mapper.Map<Reclamacao>(model);
            reclamacao.Status = StatusReclamacao.Aberto;
            reclamacao.AutorId = autorId;
            var add = unitOfWork.Reclamacoes.Add(reclamacao);

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                if (ReclamacaoExists(reclamacao.Id))
                {
                    Response.StatusCode = StatusCode.Conflict;
                    Response.Successful = false;
                    Response.ErroMessages.Add("Não foi possível adicionar uma nova Reclamacao ao sistema"); //TODO mudar pra um arquivo de resources
                }
                else
                {
                    //TODO Log de erro
                    Debug.Write(e.Message);
                    throw;
                }
            }

            return Mapper.Map<ReclamacaoModel>(add);
        }

        public async Task Update(ReclamacaoModel entity)
        {
            var Reclamacao = Mapper.Map<Reclamacao>(entity);
            unitOfWork.Reclamacoes.Update(Reclamacao);

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch
            {
                if (!ReclamacaoExists(entity.Id))
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

        public ReclamacaoModel Delete(ReclamacaoModel entity)
        {
            var Reclamacao = Mapper.Map<Reclamacao>(entity);
            var delete = unitOfWork.Reclamacoes.Delete(Reclamacao);
            unitOfWork.CommitAsync();
            return Mapper.Map<ReclamacaoModel>(delete);
        }

        public void Dispose()
        {
            _response = null;
            unitOfWork.Dispose();
        }

        private bool ReclamacaoExists(Guid id)
        {
            return unitOfWork.Reclamacoes.Find(e => e.Id == id).Any();
        }
    }
}
