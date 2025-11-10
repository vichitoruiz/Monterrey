using System;
namespace SSEL.MONTERREY.Domain.Entities;
public class FOSE {
  public int Id { get; set; }
  public string Periodo { get; set; } = ""; // YYYY-MM
  public decimal FactorDescuento { get; set; }
  public decimal LimiteInferior { get; set; } = 0m;
  public decimal LimiteSuperior { get; set; } = 140m;
  public DateTime FechaRegistro { get; set; } = DateTime.Now;
}
