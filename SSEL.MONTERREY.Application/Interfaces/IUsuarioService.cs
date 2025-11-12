using SSEL.MONTERREY.Application.DTOs;
using SSEL.MONTERREY.Application.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Application.Interfaces
{
    /// <summary>
    /// Define las operaciones del servicio de usuarios en la capa de aplicación.
    /// </summary>
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> ListarAsync();
        Task<UsuarioDto?> BuscarPorDniAsync(string dni);
        Task<Result> CrearAsync(UsuarioDto dto);
        Task<Result> ActualizarAsync(UsuarioDto dto);
        Task<Result> EliminarAsync(int id);
    }
}
