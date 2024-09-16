using System;
using System.Collections.Generic;

namespace sgiTechStore.Models;

public partial class ProdXCat
{
    public int IdPxc { get; set; }

    public int? IdCat { get; set; }

    public int? IdProd { get; set; }

    public virtual Categoria? IdCatNavigation { get; set; }

    public virtual Producto? IdProdNavigation { get; set; }
}
