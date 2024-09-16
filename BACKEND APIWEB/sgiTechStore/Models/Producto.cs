using System;
using System.Collections.Generic;

namespace sgiTechStore.Models;

public partial class Producto
{
    public int IdProd { get; set; }

    public string? NombProd { get; set; }

    public string? DescripProd { get; set; }

    public decimal? Precio { get; set; }

    public string? Marca { get; set; }

    public DateOnly? FechaFabricacion { get; set; }

    public virtual ICollection<ProdXCat> ProductosXcategoria { get; set; } = new List<ProdXCat>();
}
