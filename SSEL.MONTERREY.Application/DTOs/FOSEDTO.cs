namespace SSEL.MONTERREY.Application.DTOs;

public class FOSEDTO
{
    public int Id { get; set; }
    public string Periodo { get; set; } = "";
    public decimal FactorDescuento { get; set; }
    public decimal LimiteInferior { get; set; }
    public decimal LimiteSuperior { get; set; }
}
