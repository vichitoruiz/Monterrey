using SSEL.MONTERREY.Infrastructure.Services;
using Xunit;
using FluentAssertions;

namespace SSEL.MONTERREY.Tests.UnitTests;

public class FoseCalculatorTests
{
    [Fact]
    public void CalcularDescuento_DeberiaAplicarDescuento()
    {
        // Arrange
        decimal consumo = 80m;
        decimal factor = 0.1m;

        // Act
        var descuento = FoseCalculator.CalcularDescuento(consumo, factor, 140m);

        // Assert
        descuento.Should().Be(8m);
    }

    [Fact]
    public void CalcularDescuento_NoDebeAplicarPorExceso()
    {
        var consumo = 200m;
        var factor = 0.1m;
        var descuento = FoseCalculator.CalcularDescuento(consumo, factor);
        descuento.Should().Be(0m);
    }
}
