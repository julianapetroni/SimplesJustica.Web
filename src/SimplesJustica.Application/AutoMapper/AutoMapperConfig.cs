namespace SimplesJustica.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            global::AutoMapper.Mapper.Initialize(config =>
            {
                config.AddProfile(new CpfProfile());
                config.AddProfile(new EmailProfile());
                config.AddProfile(new GeneroProfile());
                config.AddProfile(new AcusadoProfile());
            });
        }
    }
}
