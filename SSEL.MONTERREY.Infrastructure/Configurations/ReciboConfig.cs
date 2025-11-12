using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSEL.MONTERREY.Domain.Entities;

namespace SSEL.MONTERREY.Infrastructure.Configurations;

public class ReciboConfig : IEntityTypeConfiguration<Recibo>
{
    public void Configure(EntityTypeBuilder<Recibo> b)
    {
        b.ToTable("Recibos");
        b.HasKey(x => x.Id);
        b.Property(x => x.NumeroRecibo).HasMaxLength(20).IsRequired();
        b.Property(x => x.Periodo).HasMaxLength(7).IsRequired();
        b.Property(x => x.Estado).HasMaxLength(20).HasDefaultValue("Pendiente");

        b.HasIndex(x => x.NumeroRecibo).IsUnique();
        b.HasIndex(x => new { x.Periodo, x.UsuarioId, x.Estado });

        b.HasOne<Usuario>()
         .WithMany()
         .HasForeignKey(x => x.UsuarioId)
         .OnDelete(DeleteBehavior.Restrict);

        b.HasOne<Suministro>()
         .WithMany()
         .HasForeignKey(x => x.SuministroId)
         .OnDelete(DeleteBehavior.Restrict);
    }
}
