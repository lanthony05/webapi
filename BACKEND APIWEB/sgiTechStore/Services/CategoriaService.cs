using Microsoft.EntityFrameworkCore;
using sgiTechStore.Interfaces;
using sgiTechStore.Models;
using sgiTechStore.Utilitarios;
using System.Linq.Expressions;

namespace sgiTechStore.Services
{
    public class CategoriaService:ICategoria
    {
        private readonly SgiTechStoreContext _context;
        private readonly ControlErrores Log = new ControlErrores();
        private DinamicEmpty empty = new DinamicEmpty();

        public CategoriaService(SgiTechStoreContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetCategoria(int? categoriaID)
        {
            var respuesta = new Respuesta();
            Expression<Func<Categoria, bool>> variable = x => true;
            try
            {
                if (categoriaID!= null)
                {
                    variable = x => x.IdCat == categoriaID;
                }
                respuesta.Data = await _context.Categorias.Where(variable).ToListAsync();
                /*respuesta.Data = await _context.ProductosXcategorias.Include(x => x.IdCatNavigation)
                    .Include(x => x.IdProdNavigation).Where (variable).Select(x => new {
                        idCat = x.IdCat,
                        nomCat = x.IdCatNavigation.NombCat,
                        nomProd =  x.IdProdNavigation.NombProd
                    }).ToListAsync();*/

                respuesta.Cod = empty.IsEmpty(respuesta.Data) ? "204" : "200";
                respuesta.Mensaje = empty.IsEmpty(respuesta.Data) ? $"No se encontro registro con opcion:'{categoriaID}' ": "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CategoriaService", "GetCategoria", ex.Message);
            }
            return respuesta;
        }


        public async Task<Respuesta> PostCategoria(Categoria categoria)
        {
            var respuesta = new Respuesta();
            try
            {                
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CategoriaService", "PostCategoria", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutCategoria(Categoria categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                bool existingCategoria = await _context.Categorias.AnyAsync(x => x.IdCat == categoria.IdCat);
                if (existingCategoria)
                {                    

                    _context.Categorias.Update(categoria);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizó correctamente";
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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CategoriaService", "PutCategoria", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteCategoria(Categoria categoria)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                bool existingCategoria = await _context.Categorias.AnyAsync(x => x.IdCat == categoria.IdCat);
                if (existingCategoria)
                {                   
                    
                    _context.Categorias.Remove(categoria);
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
                Log.LogErrorMetodos("CategoriaService", "DeleteCategoria", ex.Message);
            }
            return respuesta;
        }
    }
}
