using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargaDwhVenta.Dato.Entities.DwVentas.Configuracion
{
    public partial class DimEmployeeConfiguration : IEntityTypeConfiguration<DimEmployee>
    {
        public void Configure(EntityTypeBuilder<DimEmployee> entity)
        {
            entity.HasKey(e => e.EmployeeKey);

            entity.Property(e => e.EmployeeName)
                .HasMaxLength(200)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<DimEmployee> entity);
    }
}
