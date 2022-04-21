using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Infra.Data.SqlServer.Contexto
{
    public class FabricaContexto : IDesignTimeDbContextFactory<AppContexto>
    {
        public AppContexto CreateDbContext(string[] args)
        {
            var connectionString = "Server=NOTEDESADM53;Database=TodoApp;User Id=sa;Password=123456;";
            var optionBuilder = new DbContextOptionsBuilder<AppContexto>();
            optionBuilder.UseSqlServer(connectionString);

            return new AppContexto(optionBuilder.Options);
        }
    }
}
