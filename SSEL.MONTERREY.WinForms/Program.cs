using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSEL.MONTERREY.Infrastructure;
using SSEL.MONTERREY.Application.Services;
using SSEL.MONTERREY.Application.Interfaces;
using SSEL.MONTERREY.Licensing;
using SSEL.MONTERREY.Application.Mappers;
using AutoMapper;
using System;
using System.Windows.Forms;

namespace SSEL.MONTERREY.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Inicializa configuración de Windows Forms
            ApplicationConfiguration.Initialize();

            // 1️⃣ Cargar configuración de appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // 2️⃣ Configurar el contenedor de dependencias (DI)
            var services = new ServiceCollection();

            // Registrar capas e infraestructura
            services.AddInfrastructure(configuration);

            // Registrar AutoMapper (mapeos entre entidades y DTOs)
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // Registrar servicios de aplicación
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILecturaService, LecturaService>();
            services.AddScoped<IReciboService, ReciboService>();
            services.AddScoped<IReclamoService, ReclamoService>();

            // Crear el ServiceProvider
            var provider = services.BuildServiceProvider();

            // 3️⃣ Validar licencia al inicio
            if (!LicenseValidator.ValidateAtStartup())
            {
                using var formLic = new LicenseForm();
                formLic.ShowDialog();

                if (!LicenseValidator.ValidateAtStartup())
                    return; // detener aplicación si sigue sin licencia
            }

            // 4️⃣ Ejecutar la aplicación principal
            Application.Run(new Forms.FrmDashboard(provider));
        }
    }
}
