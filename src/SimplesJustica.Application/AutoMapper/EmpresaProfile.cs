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
        }
    }
}
