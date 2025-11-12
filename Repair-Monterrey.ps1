<#
───────────────────────────────────────────────
  REPAIR-MONTERREY.ps1
  Script de reparación integral para la solución
  SSEL.MONTERREY  (.NET 9.0)
───────────────────────────────────────────────
#>

Write-Host "🧹 LIMPIEZA INICIAL DE PROYECTOS..." -ForegroundColor Cyan

# 1️⃣ Eliminar bin y obj de todos los proyectos
Get-ChildItem -Recurse -Directory -Filter "bin","obj" | Remove-Item -Recurse -Force -ErrorAction SilentlyContinue

Write-Host "✅ Limpieza completada." -ForegroundColor Green

# 2️⃣ Estandarizar paquetes de AutoMapper
Write-Host "`n🧩 ACTUALIZANDO AutoMapper A VERSIÓN 15.1.0..." -ForegroundColor Cyan

$projects = @(
    ".\SSEL.MONTERREY.Application\SSEL.MONTERREY.Application.csproj",
    ".\SSEL.MONTERREY.Infrastructure\SSEL.MONTERREY.Infrastructure.csproj",
    ".\SSEL.MONTERREY.WinForms\SSEL.MONTERREY.WinForms.csproj"
)

foreach ($proj in $projects) {
    dotnet remove $proj package AutoMapper -ErrorAction SilentlyContinue | Out-Null
    dotnet remove $proj package AutoMapper.Extensions.Microsoft.DependencyInjection -ErrorAction SilentlyContinue | Out-Null
}

dotnet add .\SSEL.MONTERREY.Application\SSEL.MONTERREY.Application.csproj package AutoMapper --version 15.1.0
dotnet add .\SSEL.MONTERREY.Application\SSEL.MONTERREY.Application.csproj package AutoMapper.Extensions.Microsoft.DependencyInjection --version 15.1.0

Write-Host "✅ Paquetes AutoMapper unificados." -ForegroundColor Green

# 3️⃣ Verificar consistencia de nombres DTO
Write-Host "`n🔍 VERIFICANDO NOMBRES DE CLASE UsuarioDto / UsuarioDTO..." -ForegroundColor Cyan
$dtoFiles = Get-ChildItem -Recurse -Filter "UsuarioDTO.cs"
if ($dtoFiles.Count -gt 0) {
    Write-Host "⚠️  Se detectó 'UsuarioDTO.cs'. Se recomienda renombrarlo a 'UsuarioDto.cs' para mantener PascalCase." -ForegroundColor Yellow
}

# 4️⃣ Asegurar referencias correctas entre proyectos
Write-Host "`n🔧 VERIFICANDO REFERENCIAS ENTRE PROYECTOS..." -ForegroundColor Cyan

function Ensure-ProjectReference {
    param ($from, $to)
    $xml = [xml](Get-Content $from)
    $path = "..\" + (Split-Path $to -Leaf) + "\" + (Split-Path $to -Leaf)
    $exists = $xml.Project.ItemGroup.ProjectReference.Include -contains $path
    if (-not $exists) {
        Write-Host "➕ Agregando referencia de $from → $to" -ForegroundColor Yellow
        dotnet add $from reference $to
    }
}

Ensure-ProjectReference ".\SSEL.MONTERREY.Application\SSEL.MONTERREY.Application.csproj" ".\SSEL.MONTERREY.Domain\SSEL.MONTERREY.Domain.csproj"
Ensure-ProjectReference ".\SSEL.MONTERREY.Infrastructure\SSEL.MONTERREY.Infrastructure.csproj" ".\SSEL.MONTERREY.Domain\SSEL.MONTERREY.Domain.csproj"
Ensure-ProjectReference ".\SSEL.MONTERREY.WinForms\SSEL.MONTERREY.WinForms.csproj" ".\SSEL.MONTERREY.Application\SSEL.MONTERREY.Application.csproj"
Ensure-ProjectReference ".\SSEL.MONTERREY.WinForms\SSEL.MONTERREY.WinForms.csproj" ".\SSEL.MONTERREY.Infrastructure\SSEL.MONTERREY.Infrastructure.csproj"
Ensure-ProjectReference ".\SSEL.MONTERREY.WinForms\SSEL.MONTERREY.WinForms.csproj" ".\SSEL.MONTERREY.Domain\SSEL.MONTERREY.Domain.csproj"
Ensure-ProjectReference ".\SSEL.MONTERREY.WinForms\SSEL.MONTERREY.WinForms.csproj" ".\SSEL.MONTERREY.Licensing\SSEL.MONTERREY.Licensing.csproj"

Write-Host "✅ Referencias verificadas." -ForegroundColor Green

# 5️⃣ Restaurar y compilar la solución
Write-Host "`n⚙️  RESTAURANDO Y COMPILANDO SOLUCIÓN COMPLETA..." -ForegroundColor Cyan

dotnet restore
dotnet build --no-incremental --configuration Debug

if ($LASTEXITCODE -eq 0) {
    Write-Host "`n🎯 COMPILACIÓN EXITOSA — Sistema SSEL.MONTERREY listo." -ForegroundColor Green
} else {
    Write-Host "`n❌ COMPILACIÓN CON ERRORES. Revisar logs arriba." -ForegroundColor Red
}
