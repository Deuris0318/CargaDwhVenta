using cargaDwhVenta.ObjetoBaseDatos.Context.Configurations;
using CargaDwhVenta.Dato.Entities.DwVentas;
using CargaDwhVenta.Dato.Entities.DwVentas.Configuracion;
using Microsoft.EntityFrameworkCore;


namespace CargaDwhVenta.Dato.Contexts
{
    public partial class DwhVentasContext : DbContext
    {


        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public DwhVentasContext(DbContextOptions<DwhVentasContext> options)
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
            : base(options)
        {

        }

        public  DbSet<DimCustumer> DimCustumers { get; set; }

        public  DbSet<DimDate> DimDates { get; set; }

        public  DbSet<DimEmployee> DimEmployees { get; set; }

        public  DbSet<DimProductCategory> DimProductCategories { get; set; }

        public  DbSet<DimShipper> DimShippers { get; set; }

        public  DbSet<FactClienteAtendido> FactClienteAtendidos { get; set; }

        public  DbSet<FactOrder> FactOrders { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DimCustumerConfiguration());
            modelBuilder.ApplyConfiguration(new DimDateConfiguration());
            modelBuilder.ApplyConfiguration(new DimEmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DimProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DimShipperConfiguration());
            modelBuilder.ApplyConfiguration(new FactClienteAtendidoConfiguration());
            modelBuilder.ApplyConfiguration(new FactOrderConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
