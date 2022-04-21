using Infra.Data.SqlServer.Contexto;
using Microsoft.Extensions.DependencyInjection;
using System;

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
    }
}
