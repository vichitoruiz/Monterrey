namespace SSEL.MONTERREY.Domain.Entities;
public class Empresa {
  public int Id { get; set; }
  public string Nombre { get; set; } = "";
  public string RUC { get; set; } = "";
  public string? Direccion { get; set; }
  public string? Correo { get; set; }
  public string? Telefono { get; set; }
}
