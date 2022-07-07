using Cadastro.Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.ToTable("Cliente");

            builder.HasKey(x => x.IdCliente);

            builder.Property(x => x.Nome)
              .HasColumnName("Nome");

            builder.Property(x => x.SobreNome)
              .HasColumnName("SobreNome");

            builder.Property(x => x.Email)
              .HasColumnName("Email");

            builder.Property(x => x.DataCadastro)
              .HasColumnName("DataCadastro");

            builder.Property(x => x.Ativo)
              .HasColumnName("Ativo");
        }
    }
}
