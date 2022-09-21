
using ProyectoCafeteria.EntidadesDeNegocio;
using ProyectoCafeteria.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
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
        private ProductoBL productoBL = new ProductoBL();

        [HttpGet]
        public async Task<IEnumerable<Producto>> Get()
        {
            return await productoBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Producto> Get(int id)
        {
            Producto producto = new Producto();
            productoBL.Id = id;
            return await productoBL.ObtenerPorIdAsync(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Producto producto)
        {
            try
            {
                await productoBL.CrearAsync(producto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pProducto)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strProducto = JsonSerializer.Serialize(pProducto);
            Producto producto = JsonSerializer.Deserialize<Producto>(strProducto, option);
            if (producto.Id == id)
            {
                await productoBL.ModificarAsync(producto);
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
                Producto producto = new Producto();
                producto.Id = id;
                await productoBL.EliminarAsync(producto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Producto>> Buscar([FromBody] object pProducto)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strProducto = JsonSerializer.Serialize(pProducto);
            Producto producto = JsonSerializer.Deserialize<Producto>(strProducto, option);
            var productos = await productoBL.BuscarAsync(producto);
            return productos;
        }
    }
}
