using Xunit;
using FluentAssertions;
using SSEL.MONTERREY.Application.Services;
using SSEL.MONTERREY.Infrastructure.Repositories;
using SSEL.MONTERREY.Domain.Entities;
using AutoMapper;
using SSEL.MONTERREY.Application.Mappers;
using SSEL.MONTERREY.Tests.TestHelpers;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Tests.UnitTests;

public class UsuarioServiceTests
{
    [Fact]
    public async Task CrearUsuario_DeberiaGuardarCorrectamente()
    {
        // Arrange
        var ctx = TestDbContextFactory.Create();
        var repo = new GenericRepository<Usuario>(ctx);
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())).CreateMapper();
        var service = new UsuarioService(repo, mapper);

        var dto = new SSEL.MONTERREY.Application.DTOs.UsuarioDTO
        {
            Nombres = "Victor",
            Apellidos = "Ruiz Díaz",
            DNI = "12345678",
            Direccion = "Cajamarca"
        };

        // Act
        var result = await service.CrearAsync(dto);

        // Assert
        result.Success.Should().BeTrue();
        (await ctx.Usuarios.CountAsync()).Should().Be(1);
    }
}
