using SSEL.MONTERREY.Application.DTOs;
using SSEL.MONTERREY.Application.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Application.Interfaces;

public interface IReciboService
{
    Task<IEnumerable<ReciboDTO>> ListarPorPeriodoAsync(string periodo);
    Task<Result> GenerarReciboAsync(int usuarioId, int lecturaId);
}
