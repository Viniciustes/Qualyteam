using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyteam.Domain.Models;

namespace Qualyteam.Data.Mappings
{
    class IndicadorMensalMapping : IEntityTypeConfiguration<IndicadorMensal>
    {
        public void Configure(EntityTypeBuilder<IndicadorMensal> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("IndicadorMensal");

            builder.Property(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.DataInicio)
               .HasColumnType("Date")
               .IsRequired();
        }
    }
}
