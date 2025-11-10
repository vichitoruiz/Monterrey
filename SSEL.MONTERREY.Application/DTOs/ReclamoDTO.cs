using System;
﻿using System;

namespace SSEL.MONTERREY.Application.DTOs;

public class ReclamoDTO
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string Descripcion { get; set; } = "";
    public string Estado { get; set; } = "En proceso";
    public DateTime FechaRegistro { get; set; }
}
