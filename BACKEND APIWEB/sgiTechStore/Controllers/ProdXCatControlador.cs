using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sgiTechStore.Interfaces;
using sgiTechStore.Models;
using sgiTechStore.Utilitarios;

namespace sgiTechStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdXCatControlador : ControllerBase
    {
        private readonly IProdXCat _prodXCat;
        private ControlErrores Log = new ControlErrores();

        public ProdXCatControlador(IProdXCat prodXCat)
        {
            this._prodXCat = prodXCat;
        }

        [HttpGet]
        [Route("GetProdXCat")]
        public async Task<Respuesta> GetProdXCat(int? prodXCatID)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _prodXCat.GetProdXCat(prodXCatID);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProdXCatController", "GetProdXCat", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostProdXCat")]
        public async Task<Respuesta> PostProdXCat([FromBody] ProdXCat prodXCat)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _prodXCat.PostProdXCat(prodXCat);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProdXCatController", "PostProdXCat", ex.Message);
            }
            return respuesta;
        }

        [HttpDelete]
        [Route("DeleteProdXCat")]
        public async Task<Respuesta> DeleteProdXCat([FromBody] ProdXCat prodXCat)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _prodXCat.DeleteProdXCat(prodXCat);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProdXCatController", "DeleteProdXCat", ex.Message);
            }

            return respuesta;
        }
    }
}
