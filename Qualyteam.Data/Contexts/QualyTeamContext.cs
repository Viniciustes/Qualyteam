using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Qualyteam.Data.Mappings;
using System.IO;

namespace Qualyteam.Data.Contexts
{
    public class QualyTeamContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("ConnectionStringSqlServer"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColetaMapping());
            modelBuilder.ApplyConfiguration(new IndicadorMensalMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
