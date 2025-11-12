using System;

namespace SSEL.MONTERREY.Application.DTOs;

public class ReciboDto
{
    public int Id { get; set; }
    public string NumeroRecibo { get; set; } = "";
    public int UsuarioId { get; set; }
    public int? SuministroId { get; set; }
    public string Periodo { get; set; } = "";
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    public DateTime FechaEmision { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public string Estado { get; set; } = "Pendiente";
}
