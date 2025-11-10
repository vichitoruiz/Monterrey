using SSEL.MONTERREY.Application.DTOs;
using SSEL.MONTERREY.Application.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Application.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDto>> ListarAsync();
    Task<UsuarioDto?> BuscarPorDniAsync(string dni);
    Task CrearAsync(UsuarioDto usuario);
    Task ActualizarAsync(UsuarioDto usuario);
    Task EliminarAsync(int id);
}
