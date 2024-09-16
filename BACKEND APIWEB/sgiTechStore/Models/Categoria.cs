using System;
using System.Collections.Generic;

namespace sgiTechStore.Models;

public partial class Categoria
{
    public int IdCat { get; set; }

    public string? NombCat { get; set; }

    public virtual ICollection<ProdXCat> ProductosXcategoria { get; set; } = new List<ProdXCat>();
}
