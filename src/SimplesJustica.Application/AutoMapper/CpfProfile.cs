using AutoMapper;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Application.AutoMapper
{
    public class CpfProfile : Profile
    {
        public CpfProfile()
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
