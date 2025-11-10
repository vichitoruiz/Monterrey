using AutoMapper;
using SSEL.MONTERREY.Application.DTOs;
using SSEL.MONTERREY.Application.Helpers;
using SSEL.MONTERREY.Application.Interfaces;
using SSEL.MONTERREY.Infrastructure.Repositories;
using SSEL.MONTERREY.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SSEL.MONTERREY.Application.Services;

public class LecturaService : ILecturaService
{
    private readonly IGenericRepository<Lectura> _repo;
    private readonly IMapper _mapper;

    public LecturaService(IGenericRepository<Lectura> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LecturaDTO>> ListarPorPeriodoAsync(string periodo)
    {
        var lecturas = await _repo.GetAsync(l => l.Periodo == periodo);
        return _mapper.Map<IEnumerable<LecturaDTO>>(lecturas);
    }

    public async Task<Result> RegistrarAsync(LecturaDTO dto)
    {
        try
        {
            var entity = _mapper.Map<Lectura>(dto);
            await _repo.AddAsync(entity);
            return Result.Ok("Lectura registrada correctamente.");
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error al registrar lectura: {ex.Message}");
        }
    }
}
