using System.Web.Mvc;
using AutoMapper;
using SimplesJustica.Application.Models;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Application.AutoMapper
{
    internal class ReuProfile : Profile
    {
        internal ReuProfile()
        {
            CreateMap<Acusado, ReuModel>()
                .ReverseMap();

            CreateMap<Empresa, ReuModel>()
                .ReverseMap();

            CreateMap<Acusado, ReuCompletoModel>()
                .ForMember(entity => entity.Type, from => from.UseValue(ReuType.Acusado))
                .ReverseMap();

            CreateMap<Empresa, ReuCompletoModel>()
                .ForMember(entity => entity.Type, from => from.UseValue(ReuType.Empresa))
                .ReverseMap();
        }
    }
}
