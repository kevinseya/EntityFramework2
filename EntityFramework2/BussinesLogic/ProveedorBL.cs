using Microsoft.EntityFrameworkCore;
using EntityFramework2.Repository;
using EntityFramework2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework2.BussinesLogic
{
    public class ProveedorBL
    {
        private readonly ProveedorRepo _proveedorRepo;

        public ProveedorBL(ProveedorRepo proveedorRepo)
        {
            _proveedorRepo = proveedorRepo;
        }

        public void crearProveedor(Proveedor nuevoProveedor)
        {
            _proveedorRepo.Add(nuevoProveedor);
            _proveedorRepo.SaveChanges();
            Console.WriteLine("Proveedor creado con éxito");
        }
        public void actualizarProveedor(int id, string nombre, string direccion, string telefono)
        {
            Proveedor proveedorExistente = _proveedorRepo.Get(id);
            if (proveedorExistente != null)
            {
                proveedorExistente.Nombre = nombre;
                proveedorExistente.Direccion = direccion;
                proveedorExistente.Telefono = telefono;
                _proveedorRepo.Update(proveedorExistente);
                _proveedorRepo.SaveChanges();
                Console.WriteLine("Proveedor actualizado con éxito");
            }
            else
            {
                Console.WriteLine("Proveedor no Encontrado");
            }
        }
        public void eliminarProveedor(int id)
        {
            Proveedor proveedorExistente = _proveedorRepo.Get(id);
            if (proveedorExistente != null)
            {
                _proveedorRepo.HardDelete(proveedorExistente);
                _proveedorRepo.SaveChanges();
                Console.WriteLine("Proveedor elimnado con éxito");
            }
            else
            {
                Console.WriteLine("Proveedor no Encontrado");
            }
        }
        public void consultaProveedor()
        {
            IQueryable<Proveedor> list = _proveedorRepo.GetAll();
            foreach (var item in list)
            {
                Console.WriteLine($"ID: {item.Id_Proveedor} Nombre: {item.Nombre} Telf: {item.Telefono} Direccion: {item.Direccion}");

            }
        }

        public void consultaDatoEspecifico(string nombre)
        {
            BaseEFContext context = new BaseEFContext();
            ICollection<Proveedor> proveedores = context.Proveedores.Where(c => c.Nombre == nombre).ToList();

            foreach (var proveedor in proveedores)
            {
                Console.WriteLine("El proveedor buscado es: " + proveedor.Nombre + " Su direccion es: " + proveedor.Direccion + "Telf:" + proveedor.Telefono);
            }

        }
        public void consultaDatoEAGER()
        {
            BaseEFContext context = new BaseEFContext();
            ICollection<Proveedor> proveedores = context.Proveedores.Include(c => c.Producto).ToList();
            foreach (var item in proveedores)
            {
                Console.WriteLine($"ID: {item.Id_Proveedor} Nombre: {item.Nombre} Telf: {item.Telefono} Direccion: {item.Direccion}");

            }
        }
    }
}
