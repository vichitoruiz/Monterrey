using AutoMapper;
using SSEL.MONTERREY.Application.DTOs;
using SSEL.MONTERREY.Application.Helpers;
using SSEL.MONTERREY.Application.Interfaces;
using SSEL.MONTERREY.Infrastructure.Repositories;
using SSEL.MONTERREY.Domain.Repositories;
using SSEL.MONTERREY.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Application.Services;

public class ReciboService : IReciboService
{
    private readonly IGenericRepository<Lectura> _repoLectura;
    private readonly IGenericRepository<Recibo> _repoRecibo;
    private readonly IMapper _mapper;

    public ReciboService(
        IGenericRepository<Lectura> repoLectura,
        IGenericRepository<Recibo> repoRecibo,
        IMapper mapper)
    {
        _repoLectura = repoLectura;
        _repoRecibo = repoRecibo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReciboDto>> ListarPorPeriodoAsync(string periodo)
    {
        var recs = await _repoRecibo.GetAsync(r => r.Periodo == periodo);
        return _mapper.Map<IEnumerable<ReciboDto>>(recs);
    }

    public async Task<Result> GenerarReciboAsync(int usuarioId, int lecturaId)
    {
        try
        {
            var lectura = await _repoLectura.GetByIdAsync(lecturaId);
            if (lectura == null) return Result.Fail("Lectura no encontrada.");

            var subtotal = ReciboCalculator.CalcularSubtotal(lectura.Diferencia, 0.9m);
            var total = ReciboCalculator.CalcularTotal(subtotal, cargoFijo: 2m);

            var recibo = new Recibo
            {
                NumeroRecibo = $"RCB-{DateTime.Now:yyMMddHHmm}",
                UsuarioId = usuarioId,
                SuministroId = lectura.SuministroId,
                LecturaId = lectura.Id,
                Periodo = lectura.Periodo,
                SubTotal = subtotal,
                Total = total,
                FechaEmision = DateTime.Today,
                FechaVencimiento = DateTime.Today.AddDays(30)
            };

            await _repoRecibo.AddAsync(recibo);
            return Result.Ok("Recibo generado correctamente.");
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error al generar recibo: {ex.Message}");
        }
    }
}
