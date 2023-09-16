using System;
using System.Collections.Generic;

namespace ApiAgenda.Models;

public partial class Usuario
{
    public int IdUsuarios { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }
}
