using Xunit;
using FluentAssertions;
using SSEL.MONTERREY.Infrastructure.Services;

namespace SSEL.MONTERREY.Tests.UnitTests;

public class ReciboServiceTests
{
    [Fact]
    public void CalcularSubtotal_DeberiaMultiplicarCorrectamente()
    {
        var subtotal = ReciboCalculator.CalcularSubtotal(10, 0.9m);
        subtotal.Should().Be(9.0m);
    }

    [Fact]
    public void CalcularTotal_DeberiaSumarCorrectamente()
    {
        var total = ReciboCalculator.CalcularTotal(9, cargoFijo: 2, alumbradoPublico: 1);
        total.Should().Be(12.0m);
    }
}
