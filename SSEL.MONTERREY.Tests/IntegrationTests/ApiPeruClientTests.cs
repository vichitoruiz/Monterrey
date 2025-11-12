using Xunit;
using System.Threading.Tasks;
using SSEL.MONTERREY.Infrastructure.Services;
using System.Net.Http;

namespace SSEL.MONTERREY.Tests.IntegrationTests;

public class ApiPeruClientTests
{
    [Fact(Skip = "Evitar llamadas reales durante desarrollo")]
    public async Task ConsultarDniAsync_DeberiaDevolverDatos()
    {
        var client = new HttpClient();
        var api = new ApiPeruClient(client, "https://apiperu.dev/api/dni/", "91e68fbed10ce5d115985b169d12a65b10b85f29452337a9d809bebf298e9bf3");

        var (ok, nombres, apellidos, err) = await api.ConsultarDniAsync("12345678");

        Assert.True(ok, err);
        Assert.NotNull(nombres);
    }
}
