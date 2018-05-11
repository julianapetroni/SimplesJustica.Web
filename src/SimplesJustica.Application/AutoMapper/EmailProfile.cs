using AutoMapper;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Application.AutoMapper
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            CreateMap<string, Email>().ConvertUsing<EmailTypeConverter>();
            CreateMap<Email, string>().ConvertUsing(email => email.StringValue);
        }
    }

    internal class EmailTypeConverter : ITypeConverter<string, Email>
    {
        public Email Convert(string source, Email destination, ResolutionContext context)
        {
            return new Email(source);
        }
    }
}
