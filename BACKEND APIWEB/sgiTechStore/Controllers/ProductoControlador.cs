using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sgiTechStore.Interfaces;
using sgiTechStore.Models;
using sgiTechStore.Utilitarios;

namespace sgiTechStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoControlador : ControllerBase
    {
        private readonly IProducto _producto;
        private ControlErrores Log = new ControlErrores();

        public ProductoControlador(IProducto producto)
        {
            this._producto = producto;
        }

        [HttpGet]
        [Route("GetProducto")]
        public async Task<Respuesta> GetProducto(int? productoID)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.GetProducto(productoID);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "GetProducto", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostProducto")]
        public async Task<Respuesta> PostProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PostProducto(producto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PostProducto", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutProducto")]
        public async Task<Respuesta> PutProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PutProducto(producto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PutProducto", ex.Message);
            }
            return respuesta;
        }

        [HttpDelete]
        [Route("DeleteProducto")]
        public async Task<Respuesta> DeleteProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.DeleteProducto(producto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "DeleteProducto", ex.Message);
            }

            return respuesta;
        }
    }
}
