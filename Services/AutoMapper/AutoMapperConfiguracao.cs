using AutoMapper;

namespace Services.AutoMapper
{
    public class AutoMapperConfiguracao
    {
        public static MapperConfiguration Registrar()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperMapeamento());
            });
        }
    }
}
