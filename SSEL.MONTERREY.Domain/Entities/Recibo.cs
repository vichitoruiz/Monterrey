using System;
namespace SSEL.MONTERREY.Domain.Entities;
public class Recibo {
  public int Id { get; set; }
  public string NumeroRecibo { get; set; } = "";
  public int UsuarioId { get; set; }
  public int? SuministroId { get; set; }
  public string Periodo { get; set; } = "";
  public int? LecturaId { get; set; }
  public decimal Total { get; set; }
  public decimal SubTotal { get; set; }
  public DateTime FechaEmision { get; set; } = DateTime.Today;
  public DateTime? FechaVencimiento { get; set; }
  public DateTime? FechaCorte { get; set; }
  public string? HashDigital { get; set; }
  public string Estado { get; set; } = "Pendiente";
}
