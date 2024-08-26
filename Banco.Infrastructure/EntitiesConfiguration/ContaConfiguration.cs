using Banco.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Infrastructure.EntitiesConfiguration
{
    public class ContaConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(t => t.ContaId);
            builder.Property(p => p.Tipo).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Saldo).HasPrecision(10, 2);


            builder.HasOne(e => e.Cliente).WithMany(e => e.Contas)
                .HasForeignKey(e => e.ClienteId);

           
        }
    }
}
