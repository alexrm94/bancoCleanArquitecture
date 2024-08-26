using Banco.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banco.Infrastructure.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(t => t.ClienteId);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            

            builder.HasData(
              new Cliente(1, "Alex"),
              new Cliente(2, "Beatriz"),
              new Cliente(3, "Carlos")
            );
        }
    }
}
