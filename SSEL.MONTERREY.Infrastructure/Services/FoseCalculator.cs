namespace SSEL.MONTERREY.Infrastructure.Services;

public static class FoseCalculator
{
    /// <summary>
    /// Regla: Si consumo <= límite superior, aplica descuento por factor. Caso contrario 0.
    /// </summary>
    public static decimal CalcularDescuento(decimal consumoKWh, decimal factor, decimal limiteSuperior = 140m)
        => (consumoKWh > 0 && consumoKWh <= limiteSuperior) ? consumoKWh * factor : 0m;
}
