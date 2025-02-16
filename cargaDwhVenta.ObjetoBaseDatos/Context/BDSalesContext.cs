﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using cargaDwhVenta.ObjetoBaseDatos.Context.Configurations;
using cargaDwhVenta.ObjetoBaseDatos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
#nullable disable

namespace cargaDwhVenta.ObjetoBaseDatos.Context;

public partial class BDSalesContext : DbContext
{
    public BDSalesContext()
    {
    }

    public BDSalesContext(DbContextOptions<BDSalesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DimCustumer> DimCustumers { get; set; }

    public virtual DbSet<DimDate> DimDates { get; set; }

    public virtual DbSet<DimEmployee> DimEmployees { get; set; }

    public virtual DbSet<DimProductCategory> DimProductCategories { get; set; }

    public virtual DbSet<DimShipper> DimShippers { get; set; }

    public virtual DbSet<FactClienteAtendido> FactClienteAtendidos { get; set; }

    public virtual DbSet<FactOrder> FactOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-OVERP8Q\\SQLEXPRESS;Initial Catalog=DwVentas;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.DimCustumerConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.DimDateConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.DimEmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.DimProductCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.DimShipperConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.FactClienteAtendidoConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.FactOrderConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
