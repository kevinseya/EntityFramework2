using EntityFramework2.Models;
using EntityFramework2.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework2.BussinesLogic
{
    public class VentaBL
    {
        private readonly VentaRepo _ventaRepo;

        public VentaBL(VentaRepo ventaRepo)
        {
            _ventaRepo = ventaRepo;
        }

        public void crearVenta(Venta nuevaVenta)
        {
            _ventaRepo.Add(nuevaVenta);
            _ventaRepo.SaveChanges();
            Console.WriteLine("Venta creada con éxito");
        }
        public void actualizarVenta(int id, int cantidad, int idFactura, int idProducto)
        {
            Venta ventaExistente = _ventaRepo.Get(id);
            if (ventaExistente != null)
            {
                ventaExistente.Cantidad = cantidad;
                ventaExistente.Id_Factura = idFactura;
                ventaExistente.Id_Producto = idProducto;
                _ventaRepo.Update(ventaExistente);
                _ventaRepo.SaveChanges();
                Console.WriteLine("Venta actualizada con éxito");
            }
            else
            {
                Console.WriteLine("Venta no Encontrado");
            }
        }
        public void eliminarVenta(int id)
        {
            Venta ventaExistente = _ventaRepo.Get(id);
            if (ventaExistente != null)
            {
                _ventaRepo.HardDelete(ventaExistente);
                _ventaRepo.SaveChanges();
                Console.WriteLine("Venta elimnada con éxito");
            }
            else
            {
                Console.WriteLine("Factura no Encontrada");
            }
        }
        public void consultaVenta()
        {
            IQueryable<Venta> list = _ventaRepo.GetAll();
            foreach (var item in list)
            {
                Console.WriteLine($"ID: {item.Id_Venta} ID Factura: {item.Id_Factura} Producto: {item.Id_Producto} Cantidad:{item.Cantidad}");

            }
        }

        public void consultaDatoEspecifico(string nombreProducto)
        {
            BaseEFContext context = new BaseEFContext();
            int idProducto = context.Productos.Where(c => c.Descripcion == nombreProducto).Select(c => c.Id_Producto).FirstOrDefault();
            ICollection<Venta> ventas = context.Ventas.Where(factura => factura.Id_Producto == idProducto).ToList();
            foreach (var item in ventas)
            {
                Console.WriteLine($"ID: {item.Id_Venta} ID Factura: {item.Id_Factura}");
            }

        }
        public void consultaDatoEAGER()
        {
            BaseEFContext context = new BaseEFContext();
            ICollection<Venta> ventas = context.Ventas.Include(c => c.Facturas).ThenInclude(f=>f.Clientes).Include(c => c.Productos).ToList();
            foreach (var item in ventas)
            {
                Console.WriteLine("****************************************************");
                Console.WriteLine($"ID Venta: {item.Id_Venta}, Cantidad: {item.Cantidad}");
                Console.WriteLine($"  Factura ID: {item.Facturas.Id_Factura}, Fecha: {item.Facturas.Fecha}");
                Console.WriteLine($"    Cliente: ID: {item.Facturas.Id_Cliente}, Nombre: {item.Facturas.Clientes.Nombres}");
                Console.WriteLine($"    Producto: ID: {item.Productos.Id_Producto}, Descripción: {item.Productos.Descripcion}, Precio: {item.Productos.precio}");
            }
        }


        public void realizarVenta()
        {
            Factura facturaNueva = null;

            BaseEFContext ctx = new BaseEFContext();
            FacturaRepo facturaRepo = new FacturaRepo(ctx);
            ClienteRepo clienteRepo = new ClienteRepo(ctx);
            ProductoRepo productoRepo = new ProductoRepo(ctx);

            FacturaBL facturaBL = new FacturaBL(facturaRepo);
            ClienteBL clienteBL = new ClienteBL(clienteRepo);
            ProductoBL productoBL = new ProductoBL(productoRepo);


            Cliente cliente = null;
            Console.WriteLine("¿Es cliente?(S/N): ");
            string clienteRespuesta = Console.ReadLine();
            if (clienteRespuesta == "S" || clienteRespuesta == "s")
            {


                Console.WriteLine("Ingrese el nombre del cliente: ");
                string nombreCliente = Console.ReadLine();
                cliente = ctx.Clientes.FirstOrDefault(c => c.Nombres == nombreCliente);
                int idCliente = cliente.Id_Cliente;
                facturaNueva = new Factura { Fecha = DateTime.Now, Id_Cliente = idCliente };
                facturaBL.crearFactura(facturaNueva);
                if (cliente == null)
                {
                    Console.WriteLine("Cliente no encontrado");
                    return;
                }
            }
            else
            {
                Console.Write("Ingrese los datos del cliente\n");
                Console.Write("Ingrese los Nombres: ");
                string nuevoNombre = Console.ReadLine();
                Console.Write("Ingrese la dirección: ");
                string nuevaDireccion = Console.ReadLine();
                Console.Write("Ingrese el telefono: ");
                string nuevoTelf = Console.ReadLine();
                Cliente nuevoCliente = new Cliente { Nombres = nuevoNombre, Direccion = nuevaDireccion, Telefono = nuevoTelf };
                clienteBL.crearCliente(nuevoCliente);
                int idClienteCreado = nuevoCliente.Id_Cliente;
                Console.WriteLine("Cliente Creado");
                facturaNueva = new Factura { Fecha = DateTime.Now, Id_Cliente = idClienteCreado };
                facturaBL.crearFactura(facturaNueva);
            }

            bool seguirComprando = true;
            while (seguirComprando)
            {

                Console.WriteLine("Estos son los productos disponibles: ");
                productoBL.consultaProducto();
                Console.WriteLine("***************************************************");
                Console.WriteLine("Ingrese el ID del producto a comprar:");
                if (int.TryParse(Console.ReadLine(), out int idProductoSeleccionado))
                {
                    var producto = ctx.Productos.FirstOrDefault(p => p.Id_Producto == idProductoSeleccionado);
                    if (producto == null)
                    {
                        Console.WriteLine("Producto no encontrado.");
                        return;
                    }
                    Console.WriteLine($"Producto seleccionado => ID: {producto.Id_Producto}, Descripción: {producto.Descripcion}");
                    Console.WriteLine("Ingrese la cantidad: ");
                    if (int.TryParse(Console.ReadLine(), out int cantidad))
                    {

                        Venta nuevaVenta = new Venta { Id_Factura = facturaNueva.Id_Factura, Id_Producto = producto.Id_Producto, Cantidad = cantidad };
                        crearVenta(nuevaVenta);
                        Console.WriteLine("Producto Seleccionado.");
                        Console.WriteLine("¿Desea agregar otro producto a la compra? (S/N): ");
                        string respuesta = Console.ReadLine();

                        if (respuesta.ToUpper() != "S")
                        {
                            seguirComprando = false;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Cantidad no válida.");
                        return;
                    }

                }
            }
            Console.WriteLine("Compra realizada, su factura es:");
            facturaBL.consultaFacturaUnica(facturaNueva.Id_Factura);

        }

    }
}
