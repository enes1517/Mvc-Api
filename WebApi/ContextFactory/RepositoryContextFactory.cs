using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EFCore;

namespace WebApi.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            // configuration builder
            var ConfigurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();


            // DbContextOptions builder         
            var builder = new DbContextOptionsBuilder<RepositoryContext>().UseSqlServer(ConfigurationBuilder.GetConnectionString("SqlConnection"),
                prj => prj.MigrationsAssembly("WebApi"));
            return new RepositoryContext(builder.Options);
        }
    }
}
