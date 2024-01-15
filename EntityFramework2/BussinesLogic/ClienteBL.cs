using Microsoft.EntityFrameworkCore;
using EntityFramework2.Repository;
using EntityFramework2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework2.Repository;

namespace EntityFramework2.BussinesLogic
{
    public class ClienteBL
    {
        private readonly ClienteRepo _clienteRepo;

        public ClienteBL(ClienteRepo clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public void crearCliente(Cliente nuevoCliente)
        {
            _clienteRepo.Add(nuevoCliente);
            _clienteRepo.SaveChanges();
            Console.WriteLine("Cliente creado con éxito");
        }
        public void actualizarCliente(int idCliente, string Nombres, string Telefono, string Direccion)
        {
            Cliente clienteExistente = _clienteRepo.Get(idCliente);
            if (clienteExistente != null)
            {
                clienteExistente.Direccion = Direccion;
                clienteExistente.Nombres = Nombres;
                clienteExistente.Telefono = Telefono;
                _clienteRepo.Update(clienteExistente);
                _clienteRepo.SaveChanges();
                Console.WriteLine("Cliente actualizado con éxito");
            }
            else
            {
                Console.WriteLine("Cliente no Encontrado");
            }
        }
        public void eliminarCliente(int idCliente)
        {
            Cliente clienteExistente = _clienteRepo.Get(idCliente);
            if (clienteExistente != null)
            {
                _clienteRepo.HardDelete(clienteExistente);
                _clienteRepo.SaveChanges();
                Console.WriteLine("Cliente elimnado con éxito");
            }
            else
            {
                Console.WriteLine("Cliente no Encontrado");
            }
        }
        public void consultaCliente()
        {
            IQueryable<Cliente> list = _clienteRepo.GetAll();
            foreach (var item in list)
            {
                Console.WriteLine("Id Cliente: " + item.Id_Cliente + " Nombre: " + item.Nombres + " Direccion: " + item.Direccion + " Telefono: " + item.Telefono);

            }
        }

        public void consultaDatoEspecifico(string Telefono)
        {
            BaseEFContext context = new BaseEFContext();
            ICollection<Cliente> clientes = context.Clientes.Where(c => c.Telefono == Telefono).ToList();

            foreach (var cliente in clientes)
            {
                Console.WriteLine("Id Cliente: " + cliente.Id_Cliente + " Nombre: " + cliente.Nombres + " Dirección: " + cliente.Direccion + " Telefono: " + cliente.Telefono);
            }

        }
        public void consultaDatoEAGER()
        {
            BaseEFContext context = new BaseEFContext();
            ICollection<Cliente> clientes = context.Clientes.Include(c => c.Facturas).ToList();
            foreach (var item in clientes)
            {
                Console.WriteLine("ID cliente: " + item.Id_Cliente + " Nombre: " + item.Nombres + " Direccion: " + item.Direccion + " Telefono: " + item.Telefono );
            }
        }
    }
}
