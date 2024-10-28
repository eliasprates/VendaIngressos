using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace VendaIngressos.Infrastructure.Data
{
    public class VendaIngressosContextFactory : IDesignTimeDbContextFactory<VendaIngressosContext>
    {
        public VendaIngressosContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../VendaIngressos.Api")) // Caminho para a API
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<VendaIngressosContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new VendaIngressosContext(optionsBuilder.Options);
        }
    }
}
