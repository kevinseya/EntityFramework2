﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFramework2.Migrations
{
    [DbContext(typeof(BaseEFContext))]
    [Migration("20240115044635_nuevaMigracion")]
    partial class nuevaMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Property<int>("Id_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Cliente"));

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id_Cliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("EntityFramework2.Models.Categoria", b =>
                {
                    b.Property<int>("Id_Categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Categoria"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Categoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("EntityFramework2.Models.Factura", b =>
                {
                    b.Property<int>("Id_Factura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Factura"));

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Cliente")
                        .HasColumnType("int");

                    b.HasKey("Id_Factura");

                    b.HasIndex("Id_Cliente");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("EntityFramework2.Models.Producto", b =>
                {
                    b.Property<int>("Id_Producto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Producto"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Id_Categoria")
                        .HasColumnType("int");

                    b.Property<int?>("Id_Proveedor")
                        .HasColumnType("int");

                    b.Property<decimal?>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id_Producto");

                    b.HasIndex("Id_Categoria");

                    b.HasIndex("Id_Proveedor");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("EntityFramework2.Models.Proveedor", b =>
                {
                    b.Property<int>("Id_Proveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Proveedor"));

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Proveedor");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("EntityFramework2.Models.Venta", b =>
                {
                    b.Property<int>("Id_Venta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Venta"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("Id_Factura")
                        .HasColumnType("int");

                    b.Property<int?>("Id_Producto")
                        .HasColumnType("int");

                    b.HasKey("Id_Venta");

                    b.HasIndex("Id_Factura");

                    b.HasIndex("Id_Producto");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("EntityFramework2.Models.Factura", b =>
                {
                    b.HasOne("Cliente", "Clientes")
                        .WithMany("Facturas")
                        .HasForeignKey("Id_Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("EntityFramework2.Models.Producto", b =>
                {
                    b.HasOne("EntityFramework2.Models.Categoria", "Categorias")
                        .WithMany("Productos")
                        .HasForeignKey("Id_Categoria");

                    b.HasOne("EntityFramework2.Models.Proveedor", "Proveedores")
                        .WithMany("Productos")
                        .HasForeignKey("Id_Proveedor");

                    b.Navigation("Categorias");

                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("EntityFramework2.Models.Venta", b =>
                {
                    b.HasOne("EntityFramework2.Models.Factura", "Facturas")
                        .WithMany("Ventas")
                        .HasForeignKey("Id_Factura");

                    b.HasOne("EntityFramework2.Models.Producto", "Productos")
                        .WithMany("Ventas")
                        .HasForeignKey("Id_Producto");

                    b.Navigation("Facturas");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("EntityFramework2.Models.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("EntityFramework2.Models.Factura", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("EntityFramework2.Models.Producto", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("EntityFramework2.Models.Proveedor", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
