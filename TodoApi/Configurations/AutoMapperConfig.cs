using Microsoft.Extensions.DependencyInjection;
using Services.AutoMapper;
using System;


namespace TodoApi.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            AutoMapperConfiguracao.Registrar();
        }
    }
}
