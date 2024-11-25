
using CargaDwhVenta.Dato.Entities.BDSales;
using CargaDwhVenta.Dato.Entities.DwVentas;
using Microsoft.EntityFrameworkCore;

namespace CargaDwhVenta.Dato.Contexts;

public partial class BDSalesContext : DbContext
{
    public BDSalesContext(DbContextOptions<BDSalesContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Shipper> Shippers { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<Vwventas> Vwventas { get; set; }

    public DbSet<ViewClient> ViewClients { get; set; }

    public DbSet<ViewClientesAtendidosPorEmpleado> ViewClientesAtendidosPorEmpleados { get; set; }

    public DbSet<ViewOrdenesEnviadasPorTransportistum> ViewOrdenesEnviadasPorTransportista { get; set; }

    public DbSet<ViewOrdenesPorCliente> ViewOrdenesPorClientes { get; set; }

    public DbSet<ViewPedidosProcesadosPorEmpleado> ViewPedidosProcesadosPorEmpleados { get; set; }

    public DbSet<ViewProduct> ViewProducts { get; set; }

    public DbSet<ViewProductividadEmpleado> ViewProductividadEmpleados { get; set; }

    public DbSet<ViewProductosMasVendido> ViewProductosMasVendidos { get; set; }

    public DbSet<ViewProductosMasVendidosPorCategorium> ViewProductosMasVendidosPorCategoria { get; set; }

    public DbSet<ViewTotalVentasPorCategorium> ViewTotalVentasPorCategoria { get; set; }

    public DbSet<ViewTotalVentasPorCliente> ViewTotalVentasPorClientes { get; set; }

    public DbSet<ViewTotalVentasPorTransportistum> ViewTotalVentasPorTransportista { get; set; }

    public DbSet<ViewVentasPorCategorium> ViewVentasPorCategoria { get; set; }

    public DbSet<ViewVentasPorRegionPai> ViewVentasPorRegionPais { get; set; }

    public DbSet<ViewVentasTotalesPeriodo> ViewVentasTotalesPeriodos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.CategoryName, "CategoryName");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
            entity.Property(e => e.Description).HasColumnType("ntext");

        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.City, "City");

            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.HasIndex(e => e.Region, "Region");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.LastName, "LastName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Extension).HasMaxLength(4);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.HomePhone).HasMaxLength(24);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Notes).HasColumnType("ntext");

            entity.Property(e => e.PhotoPath).HasMaxLength(255);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.Title).HasMaxLength(30);
            entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "CustomerID");

            entity.HasIndex(e => e.CustomerId, "CustomersOrders");

            entity.HasIndex(e => e.EmployeeId, "EmployeeID");

            entity.HasIndex(e => e.EmployeeId, "EmployeesOrders");

            entity.HasIndex(e => e.OrderDate, "OrderDate");

            entity.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");

            entity.HasIndex(e => e.ShippedDate, "ShippedDate");

            entity.HasIndex(e => e.ShipVia, "ShippersOrders");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Freight)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");


        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK_Order_Details");

            entity.ToTable("Order Details");

            entity.HasIndex(e => e.OrderId, "OrderID");

            entity.HasIndex(e => e.OrderId, "OrdersOrder_Details");

            entity.HasIndex(e => e.ProductId, "ProductID");

            entity.HasIndex(e => e.ProductId, "ProductsOrder_Details");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Quantity).HasDefaultValue((short)1);
            entity.Property(e => e.UnitPrice).HasColumnType("money");


        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "CategoriesProducts");

            entity.HasIndex(e => e.CategoryId, "CategoryID");

            entity.HasIndex(e => e.ProductName, "ProductName");

            entity.HasIndex(e => e.SupplierId, "SupplierID");

            entity.HasIndex(e => e.SupplierId, "SuppliersProducts");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.ReorderLevel).HasDefaultValue((short)0);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.UnitsInStock).HasDefaultValue((short)0);
            entity.Property(e => e.UnitsOnOrder).HasDefaultValue((short)0);


        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.Property(e => e.ShipperID).HasColumnName("ShipperID");
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.Phone).HasMaxLength(24);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.HomePage).HasColumnType("ntext");
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
        });

        modelBuilder.Entity<Vwventas>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VWVentas", "DWH");

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.CustomerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.EmpleyeeName)
                .IsRequired()
                .HasMaxLength(31);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
        });

        modelBuilder.Entity<ViewClient>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewClients", "DWH");

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Phone).HasMaxLength(24);
        });

        modelBuilder.Entity<ViewClientesAtendidosPorEmpleado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Clientes_Atendidos_Por_Empleado", "DWH");

            entity.Property(e => e.Empleado)
                .IsRequired()
                .HasMaxLength(31);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
        });

        modelBuilder.Entity<ViewOrdenesEnviadasPorTransportistum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Ordenes_Enviadas_Por_Transportista", "DWH");

            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
            entity.Property(e => e.Transportista)
                .IsRequired()
                .HasMaxLength(40);
        });

        modelBuilder.Entity<ViewOrdenesPorCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Ordenes_Por_Cliente", "DWH");

            entity.Property(e => e.Cliente)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.CustomerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
        });

        modelBuilder.Entity<ViewPedidosProcesadosPorEmpleado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Pedidos_Procesados_Por_Empleado", "DWH");

            entity.Property(e => e.Empleado)
                .IsRequired()
                .HasMaxLength(31);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
        });

        modelBuilder.Entity<ViewProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewProducts", "DWH");

            entity.Property(e => e.Description).HasMaxLength(20);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.SellingPrice).HasColumnType("money");
        });

        modelBuilder.Entity<ViewProductividadEmpleado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Productividad_Empleados", "DWH");

            entity.Property(e => e.Empleado)
                .IsRequired()
                .HasMaxLength(31);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.TotalVentas).HasColumnType("money");
        });

        modelBuilder.Entity<ViewProductosMasVendido>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Productos_Mas_Vendidos", "DWH");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);
        });

        modelBuilder.Entity<ViewProductosMasVendidosPorCategorium>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Productos_Mas_Vendidos_Por_Categoria", "DWH");

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);
        });

        modelBuilder.Entity<ViewTotalVentasPorCategorium>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Total_Ventas_Por_Categoria", "DWH");

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
            entity.Property(e => e.TotalVentas).HasColumnType("money");
        });

        modelBuilder.Entity<ViewTotalVentasPorCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Total_Ventas_Por_Cliente", "DWH");

            entity.Property(e => e.Cliente)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.CustomerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.TotalVentas).HasColumnType("money");
        });

        modelBuilder.Entity<ViewTotalVentasPorTransportistum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Total_Ventas_Por_Transportista", "DWH");

            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
            entity.Property(e => e.TotalVentas).HasColumnType("money");
            entity.Property(e => e.Transportista)
                .IsRequired()
                .HasMaxLength(40);
        });

        modelBuilder.Entity<ViewVentasPorCategorium>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Ventas_Por_Categoria", "DWH");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
        });

        modelBuilder.Entity<ViewVentasPorRegionPai>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Ventas_Por_Region_Pais", "DWH");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
        });

        modelBuilder.Entity<ViewVentasTotalesPeriodo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Ventas_Totales_Periodo", "DWH");

            entity.Property(e => e.TotalVentas).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}