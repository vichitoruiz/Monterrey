namespace SSEL.MONTERREY.Domain.Entities;
public class Usuario {
  public int Id { get; set; }
  public string Nombres { get; set; } = "";
  public string Apellidos { get; set; } = "";
  public string DNI { get; set; } = "";
  public string? Direccion { get; set; }
  public string? Celular { get; set; }
  public string? Correo { get; set; }
  public bool Estado { get; set; } = true;
}
