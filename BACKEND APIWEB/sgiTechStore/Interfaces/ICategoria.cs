using sgiTechStore.Models;
using sgiTechStore.Utilitarios;

namespace sgiTechStore.Interfaces
{
    public interface ICategoria
    {
        Task<Respuesta> GetCategoria(int? IdCategoria);
        Task<Respuesta> PostCategoria(Categoria categoria);
        Task<Respuesta> PutCategoria(Categoria categoria);
        Task<Respuesta> DeleteCategoria(Categoria categoria);
    }    
}
