using SSEL.MONTERREY.Application.DTOs;
using SSEL.MONTERREY.Application.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Application.Interfaces;

public interface ILecturaService
{
    Task<IEnumerable<LecturaDto>> ListarPorPeriodoAsync(string periodo);
    Task<Result> RegistrarAsync(LecturaDto dto);
}
