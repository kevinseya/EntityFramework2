using EntityFramework2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class BaseEFContext : DbContext
{
    public BaseEFContext()
    {
    }
    public BaseEFContext(DbContextOptions<BaseEFContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }
    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Factura> Facturas { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }
    public virtual DbSet<Proveedor> Proveedores { get; set; }
    public virtual DbSet<Venta> Ventas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Data Source=MATEOPC;Initial Catalog=EntityFramework2;User ID=MateoMarcos;Password=MateoMarcos;TrustServerCertificate=True");



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

}
