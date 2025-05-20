using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APIProjetoFinal.Models;

public partial class Categorianota
{
    public int Idnotacategoria { get; set; }

    public int Notaid { get; set; }

    public int Idcategoria { get; set; }
    [JsonIgnore]
    public virtual Categoria IdcategoriaNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Nota Nota { get; set; } = null!;
}
