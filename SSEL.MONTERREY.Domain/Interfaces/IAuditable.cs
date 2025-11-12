using System;
namespace SSEL.MONTERREY.Domain.Interfaces;
public interface IAuditable
{
    DateTime FechaCreacion { get; set; }
    string? CreadoPor { get; set; }
    DateTime? FechaModificacion { get; set; }
    string? ModificadoPor { get; set; }
}
