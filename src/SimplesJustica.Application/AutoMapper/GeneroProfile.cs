using System;
using AutoMapper;
using SimplesJustica.Domain.Enum;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Application.AutoMapper
{
    internal class GeneroProfile : Profile
    {
        internal GeneroProfile()
        {
            CreateMap<string, Genero>().ConvertUsing<StringToGeneroConverter>();
            CreateMap<Genero.GeneroType, Genero>().ConvertUsing<GeneroTypeToGeneroConverter>();
            CreateMap<Genero, Genero.GeneroType>().ConvertUsing<GeneroToGeneroTypeConverter>();
        }
    }

    internal class GeneroTypeToGeneroConverter : ITypeConverter<Genero.GeneroType, Genero>
    {
        public Genero Convert(Genero.GeneroType source, Genero destination, ResolutionContext context)
        {
            return new Genero(source);
        }
    }

    internal class GeneroToGeneroTypeConverter : ITypeConverter<Genero, Genero.GeneroType>
    {
        public Genero.GeneroType Convert(Genero source, Genero.GeneroType destination, ResolutionContext context)
        {
            return source.TypeValue;
        }
    }

    internal class StringToGeneroConverter : ITypeConverter<string, Genero>
    {
        public Genero Convert(string source, Genero destination, ResolutionContext context)
        {
            return new Genero(source.ParseEnum<Genero.GeneroType>());
        }
    }
}
