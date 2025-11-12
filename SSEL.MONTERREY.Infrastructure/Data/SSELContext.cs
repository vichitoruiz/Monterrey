using Microsoft.EntityFrameworkCore;
using SSEL.MONTERREY.Domain.Entities;

namespace SSEL.MONTERREY.Infrastructure.Data;

public class SSELContext : DbContext
{
    public SSELContext(DbContextOptions<SSELContext> options) : base(options)
    {
    }

    // === DbSets ===
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Servicio> Servicios => Set<Servicio>();
    public DbSet<Suministro> Suministros => Set<Suministro>();
    public DbSet<Lectura> Lecturas => Set<Lectura>();
    public DbSet<Recibo> Recibos => Set<Recibo>();
    public DbSet<Reclamo> Reclamos => Set<Reclamo>();
    public DbSet<FOSE> FOSE => Set<FOSE>();
    public DbSet<Empresa> Empresa => Set<Empresa>();

    // === Configuración del modelo ===
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SSELContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
