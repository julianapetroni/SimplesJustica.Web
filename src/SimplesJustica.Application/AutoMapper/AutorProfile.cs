using AutoMapper;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Identity.Models;

namespace SimplesJustica.Application.AutoMapper
{
    internal class AutorProfile : Profile
    {
        internal AutorProfile()
        {
            CreateMap<Autor, AutorProfile>().ReverseMap();
            CreateMap<RegisterViewModel, Autor>();
        }
    }
}
