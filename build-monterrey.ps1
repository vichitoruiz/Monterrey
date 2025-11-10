# =============================================================
# 🔧 Script de mantenimiento y compilación - SSEL.MONTERREY
# Autor: Vichitoruiz (© 2025)
# Requiere: PowerShell 7+ y .NET SDK 9 instalado
# =============================================================

Write-Host "🧹 LIMPIANDO PROYECTO SSEL.MONTERREY..." -ForegroundColor Cyan

# 1️⃣ Elimina carpetas bin/obj en todos los subproyectos
Get-ChildItem -Recurse -Include bin,obj -Directory | ForEach-Object {
    try {
        Remove-Item $_.FullName -Recurse -Force -ErrorAction Stop
        Write-Host "   Carpeta eliminada: $($_.FullName)" -ForegroundColor DarkGray
    }
    catch {
        Write-Warning "No se pudo eliminar $_"
    }
}

# 2️⃣ Restaura paquetes NuGet
Write-Host "`n📦 Restaurando dependencias..." -ForegroundColor Cyan
dotnet restore --force --no-cache

if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Error durante la restauración de paquetes. Abortando." -ForegroundColor Red
    exit 1
}

# 3️⃣ Compila en orden jerárquico
$projects = @(
    "SSEL.MONTERREY.Domain",
    "SSEL.MONTERREY.Application",
    "SSEL.MONTERREY.Infrastructure",
    "SSEL.MONTERREY.Licensing",
    "SSEL.MONTERREY.WinForms",
    "SSEL.MONTERREY.WPF"
)

Write-Host "`n⚙️  COMPILANDO PROYECTOS..." -ForegroundColor Cyan

foreach ($proj in $projects) {
    $path = Join-Path -Path "." -ChildPath "$proj\$proj.csproj"
    if (Test-Path $path) {
        Write-Host "▶️  Compilando: $proj" -ForegroundColor Yellow
        dotnet build $path --configuration Debug --no-incremental
        if ($LASTEXITCODE -ne 0) {
            Write-Host "❌ Error al compilar $proj" -ForegroundColor Red
            exit 1
        }
    }
    else {
        Write-Host "⚠️  No se encontró el proyecto: $proj.csproj" -ForegroundColor DarkYellow
    }
}

# 4️⃣ Resultado final
Write-Host "`n✅ COMPILACIÓN COMPLETA SIN ERRORES" -ForegroundColor Green
Write-Host "📁 Binarios listos en las carpetas /bin/Debug/net9.0-windows7.0"
