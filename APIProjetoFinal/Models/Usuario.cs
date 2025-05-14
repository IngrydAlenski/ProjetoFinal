using System;
using System.Collections.Generic;

namespace APIProjetoFinal.Models;

public partial class Usuario
{
    public int Iduser { get; set; }

    public string Nomeuser { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();

    public virtual ICollection<Sharing> Sharings { get; set; } = new List<Sharing>();
}
