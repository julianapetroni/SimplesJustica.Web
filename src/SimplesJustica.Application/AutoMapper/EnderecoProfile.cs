using AutoMapper;
using SimplesJustica.Application.Models;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Application.AutoMapper
{
    internal class EnderecoProfile : Profile
    {
        internal EnderecoProfile()
        {
            CreateMap<Endereco, EnderecoModel>().ReverseMap();
        }
    }
}
