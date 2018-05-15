using System.Web.Mvc;
using AutoMapper;
using SimplesJustica.Application.Models;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Application.AutoMapper
{
    internal class EmpresaProfile : Profile
    {
        internal EmpresaProfile()
        {
            CreateMap<Empresa, EmpresaModel>().ReverseMap();

            CreateMap<Empresa, IdentificacaoBasicaModel>();

            CreateMap<Empresa, SelectListItem>()
                .ForMember(model => model.Text, from => from.MapFrom(entity => entity.NomeFantasia))
                .ForMember(model => model.Value, from => from.MapFrom(entity => entity.Id.ToString()));
        }
    }
}
