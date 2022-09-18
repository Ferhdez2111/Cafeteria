using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoCafeteria.AccesoADatos;
using ProyectoCafeteria.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.PruebasUnitarias
{
    [TestClass()]
        public class ProductoDALTests
        {
            private static Producto productoInicial = new Producto { Id = 2, Idcategoria = 1};

            [TestMethod()]
            public async Task T1CrearAsyncTest()
            {
                var producto = new Producto();
                producto.Idcategoria = productoInicial.Idcategoria;
                producto.Nombre = "cafe";
                producto.Precio = 1;
                producto.Imagen = "https://www.cocinayvino.com/wp-content/uploads/2016/09/tazadecafe-1-696x464.jpg";
                int result = await ProductoDAL.CrearAsync(producto);
                
                Assert.AreNotEqual(0, result);
                productoInicial.Id = producto.Id;
            }

            [TestMethod()]
            public async Task T2ModificarAsyncTest()
            {
                var producto = new Producto();
                producto.Idcategoria = productoInicial.Idcategoria;
                producto.Nombre = "cafe";
                producto.Precio = 1;
                producto.Imagen = "https://www.cocinayvino.com/wp-content/uploads/2016/09/tazadecafe-1-696x464.jpg";
                int result = await ProductoDAL.ModificarAsync(producto);
                Assert.AreNotEqual(0, result);
            }

            [TestMethod()]
            public async Task T3ObtenerPorIdAsyncTest()
            {
                var producto = new Producto();
                producto.Id = productoInicial.Id;
                var resultProducto = await ProductoDAL.ObtenerPorIdAsync(producto);
                Assert.AreEqual(producto.Id, resultProducto.Id);
            }

            [TestMethod()]
            public async Task T4ObtenerTodosAsyncTest()
            {
                var resultproductos = await ProductoDAL.ObtenerTodosAsync();
                Assert.AreNotEqual(0, resultproductos.Count);
            }

            [TestMethod()]
            public async Task T5BuscarAsyncTest()
            {
                var producto = new Producto();
                producto.Idcategoria = productoInicial.Idcategoria;
                producto.Nombre = "A";
                producto.Precio = 1;
                producto.Top_Aux = 10;
                var resultProductos = await ProductoDAL.BuscarAsync(producto);
                Assert.AreNotEqual(0, resultProductos.Count);
            }

            [TestMethod()]
            public async Task T6EliminarAsyncTest()
            {
                var producto = new Producto();
                producto.Id = productoInicial.Id;
                int result = await ProductoDAL.EliminarAsync(producto);
                Assert.AreNotEqual(0, result);
            }
        }
    }
