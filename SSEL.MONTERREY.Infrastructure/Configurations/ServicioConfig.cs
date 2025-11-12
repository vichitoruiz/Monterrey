using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSEL.MONTERREY.Domain.Entities;

namespace SSEL.MONTERREY.Infrastructure.Configurations;

public class ServicioConfig : IEntityTypeConfiguration<Servicio>
{
    public void Configure(EntityTypeBuilder<Servicio> b)
    {
        b.ToTable("Servicios");
        b.HasKey(x => x.Id);
        b.Property(x => x.Codigo).HasMaxLength(15).IsRequired();
        b.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
        b.Property(x => x.Descripcion).HasMaxLength(200);
        b.Property(x => x.Tipo).HasMaxLength(50);
        b.HasIndex(x => x.Codigo).IsUnique();
    }
}
