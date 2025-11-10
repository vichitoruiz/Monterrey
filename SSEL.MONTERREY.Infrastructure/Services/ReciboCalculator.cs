using System;

namespace SSEL.MONTERREY.Infrastructure.Services;

public static class ReciboCalculator
{
    public static decimal CalcularSubtotal(decimal consumoKWh, decimal precioKwh)
        => Math.Round(consumoKWh * precioKwh, 2);

    public static decimal CalcularTotal(
        decimal subtotal,
        decimal cargoFijo = 0m,
        decimal alumbradoPublico = 0m,
        decimal mantenimiento = 0m,
        decimal reposicion = 0m,
        decimal interes = 0m,
        decimal deudaAnterior = 0m,
        decimal descuentoFOSE = 0m)
    {
        var total = subtotal + cargoFijo + alumbradoPublico + mantenimiento + reposicion + interes + deudaAnterior - descuentoFOSE;
        return Math.Max(0, Math.Round(total, 2));
    }
}
