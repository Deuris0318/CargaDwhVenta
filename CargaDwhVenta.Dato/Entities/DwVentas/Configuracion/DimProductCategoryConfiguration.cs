using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargaDwhVenta.Dato.Entities.DwVentas.Configuracion
{
    public partial class DimProductCategoryConfiguration : IEntityTypeConfiguration<DimProductCategory>
    {
        public void Configure(EntityTypeBuilder<DimProductCategory> entity)
        {
            entity.HasKey(e => e.ProductKey);

            entity.ToTable("DimProductCategory");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<DimProductCategory> entity);
    }
}
