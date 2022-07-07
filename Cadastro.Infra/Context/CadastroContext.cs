using Cadastro.Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.Context
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options)
        {

        }

        public CadastroContext()
        {

        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroContext).Assembly);
        }
    }
}
