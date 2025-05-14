using System;
using System.Collections.Generic;

namespace APIProjetoFinal.Models;

public partial class Categoria
{
    public int Idcategoria { get; set; }

    public string Nomecategoria { get; set; } = null!;

    public DateTime Criacaodata { get; set; }

    public DateTime Atualizacaodata { get; set; }

    public virtual ICollection<Categorianota> Categorianota { get; set; } = new List<Categorianota>();
}
