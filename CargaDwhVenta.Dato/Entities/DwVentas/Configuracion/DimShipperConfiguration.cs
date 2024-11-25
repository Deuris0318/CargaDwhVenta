using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CargaDwhVenta.Dato.Entities.DwVentas.Configuracion
{
    public partial class DimShipperConfiguration : IEntityTypeConfiguration<DimShipper>
    {
        public void Configure(EntityTypeBuilder<DimShipper> entity)
        {
            entity.HasKey(e => e.ShipperKey);

            entity.ToTable("DimShipper");

            entity.Property(e => e.ShipperKey).HasColumnName("ShipperKey");
            entity.Property(e => e.ShipperName)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<DimShipper> entity);
    }
}
