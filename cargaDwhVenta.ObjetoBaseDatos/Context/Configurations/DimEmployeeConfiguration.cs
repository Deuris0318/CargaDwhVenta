﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using cargaDwhVenta.ObjetoBaseDatos.Context;
using cargaDwhVenta.ObjetoBaseDatos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace cargaDwhVenta.ObjetoBaseDatos.Context.Configurations
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
