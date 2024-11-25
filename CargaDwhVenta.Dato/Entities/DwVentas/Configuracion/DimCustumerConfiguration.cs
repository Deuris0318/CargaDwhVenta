using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargaDwhVenta.Dato.Entities.DwVentas.Configuracion
{
    public partial class DimCustumerConfiguration : IEntityTypeConfiguration<DimCustumer>
    {
        public void Configure(EntityTypeBuilder<DimCustumer> entity)
        {
            entity.HasKey(e => e.CustomerKey);

            entity.Property(e => e.CustumerName)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<DimCustumer> entity);
    }
}
