using AutoMapper;
using SimplesJustica.Application.Models;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Application.AutoMapper
{
    public class AcusadoProfile : Profile
    {
        public AcusadoProfile()
        {
            CreateMap<Acusado, AcusadoModel>().ReverseMap();
        }
    }
}
