using AutoMapper;
using SimplesJustica.Application.Models;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Application.AutoMapper
{
    internal class ConciliadorProfile : Profile
    {
        internal ConciliadorProfile()
        {
            CreateMap<Conciliador, ConciliadorModel>().ReverseMap();
        }
    }
}
