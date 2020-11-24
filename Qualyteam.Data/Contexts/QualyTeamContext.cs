using Microsoft.EntityFrameworkCore;
using Qualyteam.Data.Mappings;
using Qualyteam.Domain.Models;

namespace Qualyteam.Data.Contexts
{
    public class QualyTeamContext : DbContext
    {
        public QualyTeamContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Coleta> Coleta { get; set; }

        public DbSet<IndicadorMensal> IndicadorMensal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColetaMapping());
            modelBuilder.ApplyConfiguration(new IndicadorMensalMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
