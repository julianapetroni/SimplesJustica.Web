namespace SimplesJustica.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            global::AutoMapper.Mapper.Initialize(config =>
            {
                config.AddProfile(new AcusadoProfile());
                config.AddProfile(new AutorProfile());
                config.AddProfile(new ConciliadorProfile());
                config.AddProfile(new CpfProfile());
                config.AddProfile(new EmailProfile());
                config.AddProfile(new EmpresaProfile());
                config.AddProfile(new EnderecoProfile());
                config.AddProfile(new GeneroProfile());
                config.AddProfile(new ReclamacaoProfile());
            });
        }
    }
}
