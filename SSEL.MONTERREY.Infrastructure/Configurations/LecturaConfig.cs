using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSEL.MONTERREY.Domain.Entities;

namespace SSEL.MONTERREY.Infrastructure.Configurations;

public class LecturaConfig : IEntityTypeConfiguration<Lectura>
{
    public void Configure(EntityTypeBuilder<Lectura> b)
    {
        b.ToTable("Lecturas");
        b.HasKey(x => x.Id);
        b.Property(x => x.Tecnico).HasMaxLength(80);
        b.Property(x => x.Periodo).HasMaxLength(7).IsRequired(); // YYYY-MM

        b.HasOne<Suministro>()
         .WithMany()
         .HasForeignKey(x => x.SuministroId)
         .OnDelete(DeleteBehavior.Cascade);

        // Índice crítico de rendimiento: Zona/Ruta/Periodo
        b.HasIndex(x => new { x.ZonaId, x.RutaId, x.Periodo });
    }
}
