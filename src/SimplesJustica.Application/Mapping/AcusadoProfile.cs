using AutoMapper;
using SimplesJustica.Application.Models;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Application.Mapping
{
    public class AcusadoProfile : Profile
    {
        public AcusadoProfile()
        {
            this.CreateMap<Acusado, AcusadoModel>()
                .ForMember(model => model.CPF, from => from.MapFrom(entity => entity.CPF.StringValue))
                .ForMember(model => model.Email, from => from.MapFrom(entity => entity.Email.StringValue))
                .ForMember(model => model.Genero, from => from.MapFrom(entity => entity.Genero.StringValue));
        }
    }
}
