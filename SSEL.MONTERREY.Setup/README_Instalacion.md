# Instalación local - SSEL MONTERREY
1) Instalar SQL Server 2022 + SSMS.
2) Ejecutar el script SQL de la base SSEL_MONTERREY.
3) Abrir `SSEL_MONTERREY.sln` en Visual Studio 2022/2025.
4) Ajustar la cadena de conexión en `SSEL.MONTERREY.Infrastructure/appsettings.json`.
5) Establecer proyecto de inicio: `SSEL.MONTERREY.WinForms` (o `SSEL.MONTERREY.WPF`).
6) Compilar en Release (x64). Instalar Crystal Reports Runtime SP32 si usará reportes.
