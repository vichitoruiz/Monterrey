using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSEL.MONTERREY.Infrastructure;
using SSEL.MONTERREY.Application.Services;
using SSEL.MONTERREY.Application.Interfaces;
using SSEL.MONTERREY.Licensing; // ✅ Nuevo módulo
using AutoMapper;
using System.Windows.Forms;
using System;

namespace SSEL.MONTERREY.WinForms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // 🔧 Carga configuración
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        var config = builder.Build();

        // 💡 Configuración de dependencias
        var services = new ServiceCollection()
            .AddInfrastructure(config)
            .AddAutoMapper(typeof(SSEL.MONTERREY.Application.Mappers.AutoMapperProfile))
            .AddScoped<IUsuarioService, UsuarioService>()
            .AddScoped<ILecturaService, LecturaService>()
            .AddScoped<IReciboService, ReciboService>()
            .AddScoped<IReclamoService, ReclamoService>()
            .BuildServiceProvider();

        // 🔐 Validación de licencia robusta
        if (!LicenseValidator.ValidateAtStartup())
        {
            var formLic = new LicenseForm();
            formLic.ShowDialog();

            // Si sigue inválida, detener la app
            if (!LicenseValidator.ValidateAtStartup())
                return;
        }

        // 🚀 Inicia el sistema
        Application.Run(new Forms.FrmDashboard(services));
    }
}
