using System;
using System.Collections.Generic;
using System.Text;

namespace SimplesJustica.Application.Mapping
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.AddProfile(new AcusadoProfile());
            });
        }
    }
}
