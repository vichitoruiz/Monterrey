using SSEL.MONTERREY.Application.DTOs;
using SSEL.MONTERREY.Application.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Application.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> ListarAsync();
    Task<UsuarioDTO?> BuscarPorDniAsync(string dni);
    Task<Result> CrearAsync(UsuarioDTO dto);
    Task<Result> ActualizarAsync(UsuarioDTO dto);
    Task<Result> EliminarAsync(int id);
}
