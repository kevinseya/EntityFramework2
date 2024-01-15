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
    public class CategoriaBL
    {
        private readonly CategoriaRepo _categoriaRepo;

        public CategoriaBL(CategoriaRepo categoriaRepo)
        {
            _categoriaRepo = categoriaRepo;
        }

        public void crearCategoria(Categoria nuevoCategoria)
        {
            _categoriaRepo.Add(nuevoCategoria);
            _categoriaRepo.SaveChanges();
            Console.WriteLine("Categoria creada con éxito");
        }
        public void actualizarCategoria(int id, string descripcion)
        {
            Categoria categoriaExistente = _categoriaRepo.Get(id);
            if (categoriaExistente != null)
            {
                categoriaExistente.Descripcion = descripcion;
                _categoriaRepo.Update(categoriaExistente);
                _categoriaRepo.SaveChanges();
                Console.WriteLine("Categoria actualizado con éxito");
            }
            else
            {
                Console.WriteLine("Categoria no Encontrado");
            }
        }
        public void eliminarCategoria(int id)
        {
            Categoria categoriaExistente = _categoriaRepo.Get(id);
            if (categoriaExistente != null)
            {
                _categoriaRepo.HardDelete(categoriaExistente);
                _categoriaRepo.SaveChanges();
                Console.WriteLine("Categoria elimnado con éxito");
            }
            else
            {
                Console.WriteLine("Categoria no Encontrado");
            }
        }
        public void consultaCategoria()
        {
            IQueryable<Categoria> list = _categoriaRepo.GetAll();
            foreach (var item in list)
            {
                Console.WriteLine($"ID: {item.Id_Categoria} Descripcion: {item.Descripcion}");

            }
        }

        public void consultaDatoEspecifico(string descripcion)
        {
            BaseEFContext context = new BaseEFContext();
            ICollection<Categoria> categorias = context.Categorias.Where(c => c.Descripcion == descripcion).ToList();

            foreach (var categoria in categorias)
            {
                Console.WriteLine("La categoria buscada es: " + categoria.Descripcion);
            }

        }
        public void consultaDatoEAGER()
        {
            BaseEFContext context = new BaseEFContext();
            ICollection<Categoria> categorias = context.Categorias.Include(c => c.Producto).ToList();
            foreach (var item in categorias)
            {
                Console.WriteLine($"ID: {item.Id_Categoria} Descripcion: {item.Descripcion} ");

            }
        }
    }
}
