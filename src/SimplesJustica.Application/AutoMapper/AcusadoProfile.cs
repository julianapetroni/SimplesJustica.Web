using System.Web.Mvc;
using AutoMapper;
using SimplesJustica.Application.Models;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Application.AutoMapper
{
    internal class AcusadoProfile : Profile
    {
        internal AcusadoProfile()
        {
            CreateMap<Acusado, AcusadoModel>().ReverseMap();

            CreateMap<Acusado, IdentificacaoBasicaModel>();

            CreateMap<Acusado, SelectListItem>()
                .ForMember(model => model.Text, from => from.MapFrom(entity => entity.Nome))
                .ForMember(model => model.Value, from => from.MapFrom(entity => entity.Id.ToString()));

        }
    }
}
