namespace SSEL.MONTERREY.Domain.Entities;
public class Servicio
{
    public int Id { get; set; }
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public string? Tipo { get; set; }
    public bool Estado { get; set; } = true;
}
