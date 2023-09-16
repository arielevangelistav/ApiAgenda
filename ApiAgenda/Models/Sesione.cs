using System;
using System.Collections.Generic;

namespace ApiAgenda.Models;

public partial class Sesione
{
    public int IdSesiones { get; set; }

    public string? Usuario { get; set; }

    public string? Clave { get; set; }
}
