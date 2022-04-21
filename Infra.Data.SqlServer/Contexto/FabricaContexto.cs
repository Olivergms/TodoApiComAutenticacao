using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Data.SqlServer.Contexto
{
    public class FabricaContexto : IDesignTimeDbContextFactory<AppContexto>
    {
        private const string connectionString = "Server=NOTEDESADM53;Database=TodoApp;User Id=sa;Password=123456;";

        public AppContexto CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<AppContexto>();
            optionBuilder.UseSqlServer(connectionString);

            return new AppContexto(optionBuilder.Options);
        }

        public static string ObterConnectionString()
        {
            return connectionString;
        }
    }
}
