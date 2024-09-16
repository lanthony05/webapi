using sgiTechStore.Models;
using sgiTechStore.Utilitarios;

namespace sgiTechStore.Interfaces
{
    public interface IProdXCat
    {
        Task<Respuesta> GetProdXCat(int? IdProdXCat);        
        Task<Respuesta> DeleteProdXCat(ProdXCat producto);
        Task<Respuesta> PostProdXCat(ProdXCat producto);
    }
}
