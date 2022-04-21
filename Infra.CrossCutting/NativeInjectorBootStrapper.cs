using Dominio.Interfaces;
using Infra.Data.SqlServer.Contexto;
using Infra.Data.SqlServer.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void Configure(IServiceCollection services)
        {

        }

        private void Contexto(IServiceCollection services)
        {
            services.AddDbContext<AppContexto>();
        }

        private void RegistraRepositorio(IServiceCollection services)
        {
            services.AddScoped<ITodoRepositorio, TodoRepositorio>();
        }
    }
}
