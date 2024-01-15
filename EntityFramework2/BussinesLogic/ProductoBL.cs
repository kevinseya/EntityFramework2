using EntityFramework2.Repository;
using EntityFramework2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework2.BussinesLogic
{
    public class ProductoBL
    {

        private readonly ProductoRepo _productoRepo;

        public ProductoBL(ProductoRepo productoRepo)
        {
            _productoRepo = productoRepo;
        }

        public void crearProducto(Producto nuevoProducto)
        {
            _productoRepo.Add(nuevoProducto);
            _productoRepo.SaveChanges();
            Console.WriteLine("Producto creado con éxito");
        }
        public void actualizarProducto(int id, string descripcion, decimal precio, int idproveedor, int idcategoria)
        {
            Producto productoExistente = _productoRepo.Get(id);
            if (productoExistente != null)
            {
                productoExistente.Descripcion = descripcion;
                productoExistente.precio = precio;
                productoExistente.Id_Proveedor = idproveedor;
                productoExistente.Id_Categoria= idcategoria;

                _productoRepo.Update(productoExistente);
                _productoRepo.SaveChanges();
                Console.WriteLine("Producto actualizado con éxito");
            }
            else
            {
                Console.WriteLine("Producto no Encontrado");
            }
        }
        public void eliminarProducto(int id)
        {
            Producto productoExistente = _productoRepo.Get(id);
            if (productoExistente != null)
            {
                _productoRepo.HardDelete(productoExistente);
                _productoRepo.SaveChanges();
                Console.WriteLine("Producto elimnado con éxito");
            }
            else
            {
                Console.WriteLine("Producto no Encontrado");
            }
        }
        public void consultaProducto()
        {
            IQueryable<Producto> list = _productoRepo.GetAll();
            foreach (var item in list)
            {
                Console.WriteLine($"ID: {item.Id_Producto} Descipcion: {item.Descripcion} Precio: {item.precio} Id Proveedor:{item.Id_Proveedor}, Id Categoria: {item.Id_Categoria}");

            }
        }

        public void consultaDatoEspecifico(string nombreProveedor)
        {
            BaseEFContext context = new BaseEFContext();
            int idProveedor = context.Proveedores.Where(c => c.Nombre == nombreProveedor).Select(c => c.Id_Proveedor).FirstOrDefault();
            ICollection<Producto> productos = context.Productos.Where(producto => producto.Id_Proveedor == idProveedor).ToList();
            foreach (var item in productos)
            {
                Console.WriteLine($"ID: {item.Id_Producto} Descipcion: {item.Descripcion} Precio: {item.precio}");
            }

        }
        public void consultaDatoEAGER()
        {
            BaseEFContext context = new BaseEFContext();
            ICollection<Producto> productos = context.Productos.Include(c => c.Proveedores).Include(c => c.Categorias).ToList();
            foreach (var item in productos)
            {
                Console.WriteLine($"ID: {item.Id_Producto} Descipcion: {item.Descripcion} Precio: {item.precio} Proveedor: {item.Proveedores.Nombre} Categoria: {item.Categorias.Descripcion}");
            }
        }
    }
}
