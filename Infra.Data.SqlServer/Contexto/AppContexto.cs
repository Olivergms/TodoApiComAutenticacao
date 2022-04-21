using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Infra.Data.SqlServer.Contexto
{
    public class AppContexto : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public AppContexto(DbContextOptions<AppContexto> opt) : base(opt)
        {
        }
    }
}
