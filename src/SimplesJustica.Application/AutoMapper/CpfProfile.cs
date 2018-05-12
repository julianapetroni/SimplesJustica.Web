using AutoMapper;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Application.AutoMapper
{
    internal class CpfProfile : Profile
    {
        internal CpfProfile()
        {
            CreateMap<string, CPF>().ConvertUsing<CPFTypeConverter>();
            CreateMap<CPF, string>().ConstructUsing(cpf => cpf.Formatado);
        }
    }

    internal class CPFTypeConverter : ITypeConverter<string, CPF>
    {
        public CPF Convert(string source, CPF destination, ResolutionContext context)
        {
            return new CPF(source);
        }
    }
}
