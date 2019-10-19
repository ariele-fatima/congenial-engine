using GJJA.RegistraVoce.DataAccess.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebMVC.Factories
{
    public class WebMVCDbContextFactory : IDesignTimeDbContextFactory<RegistraVoceDbContext>
    {
        public RegistraVoceDbContext CreateDbContext(string[] args)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot config = configBuilder.Build();
            string connectionString = config.GetConnectionString("MySqlConnStr");
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<RegistraVoceDbContext>();
            optionsBuilder.UseMySQL(connectionString);
            return new RegistraVoceDbContext(optionsBuilder.Options);                 
        }
    }
}