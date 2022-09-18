using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoCafeteria.AccesoADatos;
using ProyectoCafeteria.EntidadesDeNegocio;

namespace ProyectoCafeteria.LogicaDeNegocio
{
    class CategoriaBL
    {
        public async Task<int> CrearAsync(Categoria cCategoria)
        {
            return await CategoriaDAL.CrearAsync(cCategoria);
        }

        public async Task<int> ModificarAsync(Categoria cCategoria)
        {
            return await CategoriaDAL.ModificarAsync(cCategoria);
        }

        public async Task<int> EliminarAsync(Categoria cCategoria)
        {
            return await CategoriaDAL.EliminarAsync(cCategoria);
        }

        public async Task<Categoria> ObtenerPorIdAsync(Categoria cCategoria)
        {
            return await CategoriaDAL.ObtenerPorIdAsync(cCategoria);
        }

        public async Task<List<Categoria>> ObtenerTodosAsync()
        {
            return await CategoriaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Categoria>> BuscarAsync(Categoria cCategoria)
        {
            return await CategoriaDAL.BuscarAsync(cCategoria);
        }
    }
}
