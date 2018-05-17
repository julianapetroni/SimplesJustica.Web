using System;
using AutoMapper;
using SimplesJustica.Domain.Enum;

namespace SimplesJustica.Application.AutoMapper
{
    internal class GeneroProfile : Profile
    {
        internal GeneroProfile()
        {
            CreateMap<string, Genero>().ConvertUsing<GeneroTypeConverter>();
            CreateMap<Genero.GeneroType, Genero>().ConvertUsing<GeneroTypeEnumConverter>();
        }
    }

    internal class GeneroTypeEnumConverter : ITypeConverter<Genero.GeneroType, Genero>
    {
        public Genero Convert(Genero.GeneroType source, Genero destination, ResolutionContext context)
        {
            return new Genero(source);
        }
    }

    internal class GeneroTypeConverter : ITypeConverter<string, Genero>
    {
        public Genero Convert(string source, Genero destination, ResolutionContext context)
        {
            return new Genero(source.ParseEnum<Genero.GeneroType>());
        }
    }
}
