using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargaDwhVenta.Dato.Entities.DwVentas.Configuracion
{
    public partial class DimDateConfiguration : IEntityTypeConfiguration<DimDate>
    {
        public void Configure(EntityTypeBuilder<DimDate> entity)
        {
            entity.HasKey(e => e.DateKey);

            entity.ToTable("DimDate");

            entity.Property(e => e.DateName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MonthName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.YearName)
                .HasMaxLength(50)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<DimDate> entity);
    }
}
