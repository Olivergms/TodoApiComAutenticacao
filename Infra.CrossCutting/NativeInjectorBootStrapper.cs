using Dominio.Interfaces;
using Infra.Data.SqlServer.Contexto;
using Infra.Data.SqlServer.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.services;

namespace Infra.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void Configure(IServiceCollection services)
        {
            ConfigurarContexto(services);
            RegistraRepositorio(services);
        }

        private static void ConfigurarContexto(IServiceCollection services)
        {
            services.AddDbContext<AppContexto>();
        }

        private static void RegistraRepositorio(IServiceCollection services)
        {
            services.AddScoped<ITodoRepositorio, TodoRepositorio>();
        }

        private static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<ITodoServico, TodoServico>();
        }
    }
}
