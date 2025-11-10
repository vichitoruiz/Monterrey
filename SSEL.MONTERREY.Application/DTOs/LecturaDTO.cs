using System;
﻿using System;

namespace SSEL.MONTERREY.Application.DTOs;

public class LecturaDTO
{
    public int Id { get; set; }
    public int SuministroId { get; set; }
    public string NumeroMedidor { get; set; } = "";
    public string Tecnico { get; set; } = "";
    public DateTime FechaLectura { get; set; }
    public decimal LecturaAnterior { get; set; }
    public decimal LecturaActual { get; set; }
    public string Periodo { get; set; } = "";
    public decimal Diferencia => LecturaActual - LecturaAnterior;
}
