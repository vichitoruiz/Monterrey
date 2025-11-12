using System;
namespace SSEL.MONTERREY.Domain.Entities;
public class Suministro
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string NumeroMedidor { get; set; } = "";
    public string? Direccion { get; set; }
    public int? ZonaId { get; set; }
    public int? RutaId { get; set; }
    public DateTime FechaInicio { get; set; } = DateTime.Today;
    public DateTime? FechaFin { get; set; }
    public bool Estado { get; set; } = true;
}
