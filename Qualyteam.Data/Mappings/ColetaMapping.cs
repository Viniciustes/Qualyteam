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

            builder.Property(x => x.Data)
               .HasColumnType("Date")
               .IsRequired();

            //TODO Implementar mapeamento Indicador Mensal
        }
    }
}
