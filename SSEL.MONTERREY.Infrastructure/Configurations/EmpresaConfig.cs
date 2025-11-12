using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSEL.MONTERREY.Domain.Entities;

namespace SSEL.MONTERREY.Infrastructure.Configurations;

public class EmpresaConfig : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> b)
    {
        b.ToTable("Empresa");
        b.HasKey(x => x.Id);
        b.Property(x => x.Nombre).HasMaxLength(150).IsRequired();
        b.Property(x => x.RUC).HasMaxLength(20).IsRequired();
        b.Property(x => x.Direccion).HasMaxLength(200);
        b.Property(x => x.Correo).HasMaxLength(100);
        b.Property(x => x.Telefono).HasMaxLength(20);
    }
}
