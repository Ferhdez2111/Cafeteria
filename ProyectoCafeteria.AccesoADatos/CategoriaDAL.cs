using ProyectoCafeteria.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.AccesoADatos
{
    class CategoriaDAL
    {
        public static async Task<int> CrearAsync(Categoria cCategoria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(cCategoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Categoria cCategoria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var categoria = await bdContexto.Categoria.FirstOrDefaultAsync(s => s.Id == cCategoria.Id);
                categoria.Nombre = cCategoria.Nombre;
                bdContexto.Update(categoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Categoria cCategoria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var categoria = await bdContexto.Categoria.FirstOrDefaultAsync(s => s.Id == cCategoria.Id);
                bdContexto.Categoria.Remove(categoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Categoria> ObtenerPorIdAsync(Categoria cCategoria)
        {
            var categoria = new Categoria();
            using (var bdContexto = new BDContexto())
            {
                categoria = await bdContexto.Categoria.FirstOrDefaultAsync(s => s.Id == cCategoria.Id);
            }
            return categoria;
        }
        public static async Task<List<Categoria>> ObtenerTodosAsync()
        {
            var Categorias = new List<Categoria>();
            using (var bdContexto = new BDContexto())
            {
                Categorias = await bdContexto.Categoria.ToListAsync();
            }
            return Categorias;
        }
        internal static IQueryable<Categoria> QuerySelect(IQueryable<Categoria> pQuery, Categoria cCategoria)
        {
            if (cCategoria.Id > 0)
                pQuery = pQuery.Where(s => s.Id == cCategoria.Id);

            if (!string.IsNullOrWhiteSpace(cCategoria.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(cCategoria.Nombre));
            
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (cCategoria.Top_Aux > 0)
                pQuery = pQuery.Take(cCategoria.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Categoria>> BuscarAsync(Categoria cCategoria)
        {
            var categorias = new List<Categoria>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Categoria.AsQueryable();
                select = QuerySelect(select, cCategoria);
                categorias = await select.ToListAsync();
            }
            return categorias;
        }
    }
}
