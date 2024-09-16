using sgiTechStore.Models;
using sgiTechStore.Utilitarios;

namespace sgiTechStore.Interfaces
{
    public interface IProducto
    {
        Task<Respuesta> GetProducto(int? IdProducto);
        Task<Respuesta> PostProducto(Producto producto);
        Task<Respuesta> PutProducto(Producto producto);
        Task<Respuesta> DeleteProducto(Producto producto);
    }
}
