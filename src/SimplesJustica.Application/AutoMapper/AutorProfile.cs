using AutoMapper;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Application.AutoMapper
{
    internal class AutorProfile : Profile
    {
        internal AutorProfile()
        {
            CreateMap<Autor, AutorProfile>().ReverseMap();
        }
    }
}
