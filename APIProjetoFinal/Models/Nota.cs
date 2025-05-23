using System;
using System.Collections.Generic;

namespace APIProjetoFinal.Models;

public partial class Nota
{
    public int Idnota { get; set; }

    public int Iduser { get; set; }

    public DateTime Datanota { get; set; }

    public string Titulonota { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public DateTime Atualizacaonota { get; set; }

    public string? Imagenote { get; set; }

    public bool? Statusnote { get; set; }

    public virtual ICollection<Categorianota> Categorianota { get; set; } = new List<Categorianota>();

    public virtual Usuario IduserNavigation { get; set; } = null!;

    public virtual ICollection<Sharing> Sharings { get; set; } = new List<Sharing>();
}
