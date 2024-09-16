using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sgiTechStore.Interfaces;
using sgiTechStore.Models;
using sgiTechStore.Utilitarios;

namespace sgiTechStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaControlador : ControllerBase
    {
        private readonly ICategoria _categoria;
        private ControlErrores Log = new ControlErrores();

        public CategoriaControlador(ICategoria categoria)
        {
            this._categoria = categoria;
        }

        [HttpGet]
        [Route("GetCategoria")]
        public async Task<Respuesta> GetCategoria(int? categoriaID)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _categoria.GetCategoria(categoriaID);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CategoriaController", "GetCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostCategoria")]
        public async Task<Respuesta> PostCategoria([FromBody] Categoria categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _categoria.PostCategoria(categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CategoriaController", "PostCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCategoria")]
        public async Task<Respuesta> PutCategoria([FromBody] Categoria categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _categoria.PutCategoria(categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CategoriaController", "PutCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpDelete]
        [Route("DeleteCategoria")]
        public async Task<Respuesta> DeleteCategoria([FromBody] Categoria categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _categoria.DeleteCategoria(categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CategoriaController", "DeleteCategoria", ex.Message);
            }

            return respuesta;
        }
    }
}
