using AutoMapper;
using SSEL.MONTERREY.Application.DTOs;
using SSEL.MONTERREY.Application.Helpers;
using SSEL.MONTERREY.Application.Interfaces;
using SSEL.MONTERREY.Infrastructure.Repositories;
using SSEL.MONTERREY.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace SSEL.MONTERREY.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IGenericRepository<Usuario> _repo;
    private readonly IMapper _mapper;

    public UsuarioService(IGenericRepository<Usuario> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioDTO>> ListarAsync()
    {
        var usuarios = await _repo.GetAsync();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
    }

    public async Task<UsuarioDTO?> BuscarPorDniAsync(string dni)
    {
        var usuarios = await _repo.GetAsync(u => u.DNI == dni);
        return _mapper.Map<UsuarioDTO?>(usuarios.FirstOrDefault());
    }

    public async Task<Result> CrearAsync(UsuarioDTO dto)
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

    public async Task<Result> ActualizarAsync(UsuarioDTO dto)
    {
        try
        {
            var entity = _mapper.Map<Usuario>(dto);
            await _repo.UpdateAsync(entity);
            return Result.Ok("Usuario actualizado correctamente.");
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error al actualizar: {ex.Message}");
        }
    }

    public async Task<Result> EliminarAsync(int id)
    {
        try
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return Result.Fail("Usuario no encontrado.");
            await _repo.DeleteAsync(entity);
            return Result.Ok("Usuario eliminado.");
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error al eliminar: {ex.Message}");
        }
    }
}
