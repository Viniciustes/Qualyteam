using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyteam.Domain.Models;

namespace Qualyteam.Data.Mappings
{
    class ColetaMapping : IEntityTypeConfiguration<Coleta>
    {
        public void Configure(EntityTypeBuilder<Coleta> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Coleta");

            builder.Property(x => x.Id);

            builder.HasOne(e => e.IndicadorMensal)
                .WithMany(ep => ep.Coletas)
                .IsRequired();
        }
    }
}
