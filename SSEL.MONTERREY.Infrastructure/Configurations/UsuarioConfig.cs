using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSEL.MONTERREY.Domain.Entities;

namespace SSEL.MONTERREY.Infrastructure.Configurations;

public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> b)
    {
        b.ToTable("Usuarios");
        b.HasKey(x => x.Id);
        b.Property(x => x.Nombres).HasMaxLength(80).IsRequired();
        b.Property(x => x.Apellidos).HasMaxLength(80).IsRequired();
        b.Property(x => x.DNI).HasMaxLength(12).IsRequired();
        b.Property(x => x.Direccion).HasMaxLength(150);
        b.Property(x => x.Celular).HasMaxLength(15);
        b.Property(x => x.Correo).HasMaxLength(100);
        b.HasIndex(x => x.DNI).IsUnique();
    }
}
