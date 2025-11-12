using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSEL.MONTERREY.Domain.Entities;

namespace SSEL.MONTERREY.Infrastructure.Configurations;

public class ReclamoConfig : IEntityTypeConfiguration<Reclamo>
{
    public void Configure(EntityTypeBuilder<Reclamo> b)
    {
        b.ToTable("Reclamos");
        b.HasKey(x => x.Id);
        b.Property(x => x.Descripcion).HasMaxLength(400).IsRequired();
        b.Property(x => x.Estado).HasMaxLength(20).HasDefaultValue("En proceso");

        b.HasOne<Usuario>()
         .WithMany()
         .HasForeignKey(x => x.UsuarioId)
         .OnDelete(DeleteBehavior.Restrict);

        b.HasIndex(x => x.FechaRegistro);
    }
}
