using System;
using System.Collections.Generic;

namespace APIProjetoFinal.Models;

public partial class Evento
{
    public int Idevento { get; set; }

    public string Tipoevento { get; set; } = null!;

    public string Descricaoevento { get; set; } = null!;

    public virtual ICollection<Calendario> Calendarios { get; set; } = new List<Calendario>();
}
