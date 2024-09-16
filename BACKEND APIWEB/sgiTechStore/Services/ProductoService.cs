using Microsoft.EntityFrameworkCore;
using sgiTechStore.Interfaces;
using sgiTechStore.Models;
using sgiTechStore.Utilitarios;
using System.Linq.Expressions;

namespace sgiTechStore.Services
{
    public class ProductoService:IProducto
    {
        private readonly SgiTechStoreContext _context;
        private readonly ControlErrores Log = new ControlErrores();
        private DinamicEmpty empty = new DinamicEmpty();

        public ProductoService(SgiTechStoreContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetProducto(int? productoID)
        {
            var respuesta = new Respuesta();
            Expression<Func<Producto, bool>> variable = x => true;
            try
            {
                if (productoID != null)
                {
                    variable = x => x.IdProd == productoID;
                }
                respuesta.Data = await _context.Productos.Where(variable).ToListAsync();               

                respuesta.Cod = empty.IsEmpty(respuesta.Data) ? "204" : "200";
                respuesta.Mensaje = empty.IsEmpty(respuesta.Data) ? $"No se encontro registro con opcion:'{productoID}' " : "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("ProductoService", "GetProducto", ex.Message);
            }
            return respuesta;
        }


        public async Task<Respuesta> PostProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("ProductoService", "PostProducto", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                bool existingProducto = await _context.Productos.AnyAsync(x => x.IdProd == producto.IdProd);
                if (existingProducto)
                {

                    _context.Productos.Update(producto);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizó correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "El producto no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("ProductoService", "PutProducto", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteProducto(Producto producto)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                bool existingProducto = await _context.Productos.AnyAsync(x => x.IdProd == producto.IdProd);
                if (existingProducto)
                {

                    _context.Productos.Remove(producto);
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
