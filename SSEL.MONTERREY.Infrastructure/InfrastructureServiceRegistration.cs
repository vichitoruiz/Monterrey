using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSEL.MONTERREY.Infrastructure.Data;
using SSEL.MONTERREY.Infrastructure.Repositories;
using SSEL.MONTERREY.Infrastructure.Services;
using System.Net.Http;

namespace SSEL.MONTERREY.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var cnn = config.GetConnectionString("DefaultConnection")
                  ?? "Server=localhost\\SQLEXPRESS;Database=SSEL_MONTERREY;Trusted_Connection=True;TrustServerCertificate=True;";

        services.AddDbContext<SSELContext>(opt =>
        {
            opt.UseSqlServer(cnn, sql => sql.CommandTimeout(60));
            opt.EnableSensitiveDataLogging(false);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        var baseUrl = config["ApiPeru:BaseUrl"] ?? "https://apiperu.dev/api/dni/";
        var token = config["ApiPeru:Token"] ?? "";
        services.AddHttpClient<ApiPeruClient>();
        services.AddScoped(sp => new ApiPeruClient(sp.GetRequiredService<HttpClient>(), baseUrl, token));

        return services;
    }
}
