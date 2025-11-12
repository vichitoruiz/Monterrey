using AutoMapper;
using SSEL.MONTERREY.Application.DTOs;
using SSEL.MONTERREY.Application.Helpers;
using SSEL.MONTERREY.Application.Interfaces;
using SSEL.MONTERREY.Domain.Entities;
using SSEL.MONTERREY.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Application.Services
{
    /// <summary>
    /// Servicio de gestión de usuarios.
    /// Aplica reglas de negocio y coordina las operaciones CRUD sobre la entidad Usuario.
    /// </summary>
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _repo;
        private readonly IMapper _mapper;

        public UsuarioService(IGenericRepository<Usuario> repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Lista todos los usuarios del sistema.
        /// </summary>
        public async Task<IEnumerable<UsuarioDto>> ListarAsync()
        {
            var usuarios = await _repo.GetAsync();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        /// <summary>
        /// Busca un usuario por su DNI.
        /// </summary>
        public async Task<UsuarioDto?> BuscarPorDniAsync(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return null;

            var usuarios = await _repo.GetAsync(u => u.DNI == dni);
            var usuario = usuarios.FirstOrDefault();
            return _mapper.Map<UsuarioDto?>(usuario);
        }

        /// <summary>
        /// Registra un nuevo usuario.
        /// </summary>
        public async Task<Result> CrearAsync(UsuarioDto dto)
        {
            try
            {
                var entity = _mapper.Map<Usuario>(dto);
                await _repo.AddAsync(entity);
                return Result.Ok("Usuario registrado correctamente.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error al registrar usuario: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza la información de un usuario existente.
        /// </summary>
        public async Task<Result> ActualizarAsync(UsuarioDto dto)
        {
            try
            {
                var entity = _mapper.Map<Usuario>(dto);
                await _repo.UpdateAsync(entity);
                return Result.Ok("Usuario actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error al actualizar usuario: {ex.Message}");
            }
        }

        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        public async Task<Result> EliminarAsync(int id)
        {
            try
            {
                var entity = await _repo.GetByIdAsync(id);
                if (entity == null)
                    return Result.Fail("Usuario no encontrado.");

                await _repo.DeleteAsync(entity);
                return Result.Ok("Usuario eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error al eliminar usuario: {ex.Message}");
            }
        }
    }
}
