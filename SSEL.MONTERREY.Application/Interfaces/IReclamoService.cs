using SSEL.MONTERREY.Application.DTOs;
using SSEL.MONTERREY.Application.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Application.Interfaces;

public interface IReclamoService
{
    Task<IEnumerable<ReclamoDTO>> ListarAsync();
    Task<Result> RegistrarAsync(ReclamoDTO dto);
    Task<Result> ResolverAsync(int id, string observacion);
}
