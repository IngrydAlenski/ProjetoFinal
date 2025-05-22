using System;
using System.Collections.Generic;

namespace APIProjetoFinal.Models;

public partial class Categorianota
{
    public int Idnotacategoria { get; set; }

    public int Notaid { get; set; }

    public int Idcategoria { get; set; }

    public virtual Categoria IdcategoriaNavigation { get; set; } = null!;

    public virtual Nota Nota { get; set; } = null!;
}
