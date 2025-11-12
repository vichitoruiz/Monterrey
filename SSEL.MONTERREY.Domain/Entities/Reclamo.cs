using System;
namespace SSEL.MONTERREY.Domain.Entities;
public class Reclamo
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.Today;
    public string Descripcion { get; set; } = "";
    public string Estado { get; set; } = "En proceso";
    public DateTime? FechaResolucion { get; set; }
    public string? Observacion { get; set; }
}
