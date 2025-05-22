using System;
using System.Collections.Generic;

namespace APIProjetoFinal.Models;

public partial class Calendario
{
    public int Idcalendario { get; set; }

    public int Iduser { get; set; }

    public int Idevento { get; set; }

    public DateTime Dataevento { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime Datacriacao { get; set; }

    public DateTime Atualizacaodata { get; set; }

    public virtual Evento IdeventoNavigation { get; set; } = null!;

    public virtual Usuario IduserNavigation { get; set; } = null!;
}
