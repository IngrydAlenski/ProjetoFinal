﻿using System;
using System.Collections.Generic;

namespace APIProjetoFinal.Models;

public partial class Sharing
{
    public int Idsharing { get; set; }

    public int Notaid { get; set; }

    public int Usuarioid { get; set; }

    public string Permissao { get; set; } = null!;

    public virtual Nota Nota { get; set; } = null!;
}
