using Microsoft.EntityFrameworkCore;
using sgiTechStore.Interfaces;
using sgiTechStore.Models;
using sgiTechStore.Utilitarios;
using System.Linq.Expressions;

namespace sgiTechStore.Services
{
    public class ProdXCatService:IProdXCat
    {
        private readonly SgiTechStoreContext _context;
        private readonly ControlErrores Log = new ControlErrores();
        private DinamicEmpty empty = new DinamicEmpty();

        public ProdXCatService(SgiTechStoreContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetProdXCat(int? prodxcatID)
        {
            var respuesta = new Respuesta();
            Expression<Func<ProdXCat, bool>> variable = x => true;
            try
            {
                if (prodxcatID != null)
                {
                    variable = x => x.IdPxc == prodxcatID;
                }
                respuesta.Data = await _context.ProdXCats.Include(x => x.IdCatNavigation)
                    .Include(x => x.IdProdNavigation).Where (variable).Select(x => new {
                        idCat = x.IdCat,
                        nomCat = x.IdCatNavigation.NombCat,
                        nomProd =  x.IdProdNavigation.NombProd,
                        preProd = x.IdProdNavigation.Precio
                    }).ToListAsync();

                respuesta.Cod = empty.IsEmpty(respuesta.Data) ? "204" : "200";
                respuesta.Mensaje = empty.IsEmpty(respuesta.Data) ? $"No se encontro registro con opcion:'{prodxcatID}' " : "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("ProdXCatService", "GetProdXCat", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostProdXCat(ProdXCat prodXCat)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.ProdXCats.Add(prodXCat);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("ProdXCatService", "PostProdXCat", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteProdXCat(ProdXCat prodXCat)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                bool existingProdXCat = await _context.ProdXCats.AnyAsync(x => x.IdCat == prodXCat.IdCat);
                if (existingProdXCat)
                {

                    _context.ProdXCats.Remove(prodXCat);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se ha eliminado correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "La categoría no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("ProdXCatService", "DeleteProdXCat", ex.Message);
            }
            return respuesta;
        }
    }
}
