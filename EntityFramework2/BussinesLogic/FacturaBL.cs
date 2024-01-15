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
    public class FacturaBL
    {

        private readonly FacturaRepo _facturaRepo;

        public FacturaBL(FacturaRepo facturaRepo)
        {
            _facturaRepo = facturaRepo;
        }

        public void crearFactura(Factura nuevaFactura)
        {
            _facturaRepo.Add(nuevaFactura);
            _facturaRepo.SaveChanges();
            Console.WriteLine("Factura creada con éxito");
        }
        public void actualizarFactura(int id, DateTime fecha, int idCliente)
        {
            Factura facturaExistente = _facturaRepo.Get(id);
            if (facturaExistente != null)
            {
                facturaExistente.Fecha = fecha;
                facturaExistente.Id_Cliente = idCliente;
                _facturaRepo.Update(facturaExistente);
                _facturaRepo.SaveChanges();
                Console.WriteLine("Dactura actualizada con éxito");
            }
            else
            {
                Console.WriteLine("Factura no Encontrado");
            }
        }
        public void eliminarFactura(int id)
        {
            Factura facturaExistente = _facturaRepo.Get(id);
            if (facturaExistente != null)
            {
                _facturaRepo.HardDelete(facturaExistente);
                _facturaRepo.SaveChanges();
                Console.WriteLine("Factura elimnada con éxito");
            }
            else
            {
                Console.WriteLine("Factura no Encontrada");
            }
        }
        public void consultaFactura()
        {
            IQueryable<Factura> list = _facturaRepo.GetAll();
            foreach (var item in list)
            {
                Console.WriteLine($"ID: {item.Id_Factura} fecha: {item.Fecha} Cliente:{item.Id_Cliente}");

            }
        }

        public void consultaDatoEspecifico(string nombreCliente)
        {
            BaseEFContext context = new BaseEFContext();
            int idCliente = context.Clientes.Where(c => c.Nombres == nombreCliente).Select(c => c.Id_Cliente).FirstOrDefault();
            ICollection<Factura> facturas = context.Facturas.Where(factura => factura.Id_Cliente == idCliente).ToList();
            foreach (var item in facturas)
            {
                Console.WriteLine($"ID: {item.Id_Factura} fecha: {item.Fecha}");
            }

        }
        public void consultaDatoEAGER()
        {
            BaseEFContext context = new BaseEFContext();
            ICollection<Factura> facturas = context.Facturas.Include(c => c.Clientes).Include(c => c.Ventas).ToList();
            foreach (var item in facturas)
            {
                Console.WriteLine($"ID: {item.Id_Factura} fecha: {item.Fecha} cliente: {item.Clientes.Id_Cliente}, {item.Clientes.Nombres}");
            }
        }

        public void consultaFacturaUnica(int idfactura) {
            BaseEFContext context = new BaseEFContext();
            var facturaConEager = context.Facturas
               .Where(f => f.Id_Factura == idfactura)
               .Include(f => f.Clientes)
               .Include(f => f.Ventas)
                   .ThenInclude(v => v.Productos)
               .SingleOrDefault();
            if (facturaConEager != null)
            {
                decimal totalFactura = 0;
                Console.WriteLine("****************************************************");
                Console.WriteLine($"ID Factura: {facturaConEager.Id_Factura}, Fecha: {facturaConEager.Fecha}");

                Console.WriteLine($"Cliente: ID: {facturaConEager.Clientes.Id_Cliente}, Nombre: {facturaConEager.Clientes.Nombres}");

                foreach (var venta in facturaConEager.Ventas)
                {
                    Console.WriteLine($"  Venta ID: {venta.Id_Venta}, Cantidad: {venta.Cantidad}");
                    Console.WriteLine($"    Producto: {venta.Productos.Descripcion}, Precio: {venta.Productos.precio}");


                }


            }
            else
            {
                Console.WriteLine($"No se encontró la factura con ID: {idfactura}");
            }

        }
    }
}
