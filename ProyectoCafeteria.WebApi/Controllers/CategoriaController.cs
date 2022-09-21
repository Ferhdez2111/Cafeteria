﻿using ProyectoCafeteria.EntidadesDeNegocio;
using ProyectoCafeteria.LogicaDeNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoCafeteria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private CategoriaBL categoriaBL = new CategoriaBL();

        [HttpGet]
        public async Task<IEnumerable<Categoria>> Get()
        {
            return await productoBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Categoria> Get(int id)
        {
            Categoria pcategoria = new Categoria();
            categoria.Id = id;
            return await productoBL.ObtenerPorIdAsync(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categoria categoria
            )
        {
            try
            {
                await categoriaBL.CrearAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pCategoria)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCategoria = JsonSerializer.Serialize(pCategoria);
            Categoria categoria = JsonSerializer.Deserialize<Categoria>(strCategoria, option);
            if (categoria.Id == id)
            {
                await categoriaBL.ModificarAsync(categoria);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.Id = id;
                await productoBL.EliminarAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Categoria>> Buscar([FromBody] object pCategoria)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCategoria = JsonSerializer.Serialize(pCategoria);
            Categoria categoria = JsonSerializer.Deserialize<Categoria>(strCategoria, option);
            var productos = await productoBL.BuscarIncluirDepartamentosAsync(categoria);
            productos.ForEach(s => s.Departamento.Producto = null); // Evitar la redundacia de datos
            return productos;
        }
    }
}