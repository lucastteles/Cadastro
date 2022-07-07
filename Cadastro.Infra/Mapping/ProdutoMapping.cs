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
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.ToTable("Produto");

            builder.HasKey(x => x.IdProduto);

            builder.Property(x => x.Nome)
              .HasColumnName("Nome");

            builder.Property(x => x.Disponivel)
              .HasColumnName("Disponivel");

            builder.Property(x => x.Valor)
             .HasColumnName("Valor")
             .IsRequired();

            //Relacionamento
            builder.HasOne(pd => pd.Cliente)
               .WithMany(c => c.Produto)
               .HasForeignKey(pd => pd.IdCliente);
        }
    }
}
