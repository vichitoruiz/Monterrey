using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSEL.MONTERREY.Domain.Entities;

namespace SSEL.MONTERREY.Infrastructure.Configurations;

public class SuministroConfig : IEntityTypeConfiguration<Suministro>
{
    public void Configure(EntityTypeBuilder<Suministro> b)
    {
        b.ToTable("Suministros");
        b.HasKey(x => x.Id);
        b.Property(x => x.NumeroMedidor).HasMaxLength(30).IsRequired();
        b.Property(x => x.Direccion).HasMaxLength(150);
        b.HasIndex(x => x.NumeroMedidor).IsUnique();

        b.HasOne<Usuario>()
         .WithMany()
         .HasForeignKey(x => x.UsuarioId)
         .OnDelete(DeleteBehavior.Restrict);

        // Búsquedas masivas
        b.HasIndex(x => new { x.ZonaId, x.RutaId });
    }
}
