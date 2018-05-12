using AutoMapper;
using SimplesJustica.Application.Models;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Application.AutoMapper
{
    internal class ReclamacaoProfile : Profile
    {
        internal ReclamacaoProfile()
        {
            CreateMap<Reclamacao, ReclamacaoModel>().ReverseMap();
        }
    }
}
