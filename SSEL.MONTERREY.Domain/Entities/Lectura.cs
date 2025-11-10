using System;
namespace SSEL.MONTERREY.Domain.Entities;
public class Lectura {
  public int Id { get; set; }
  public int SuministroId { get; set; }
  public string? Tecnico { get; set; }
  public DateTime FechaLectura { get; set; }
  public decimal LecturaAnterior { get; set; }
  public decimal LecturaActual { get; set; }
  public string Periodo { get; set; } = ""; // YYYY-MM
  public int? ZonaId { get; set; }
  public int? RutaId { get; set; }
  public bool EsLecturaFinal { get; set; }
  public decimal Diferencia => LecturaActual - LecturaAnterior;
}
