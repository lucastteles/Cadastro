using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Entidade
{
    public class Cliente
    {
        public int IdCliente  { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public ICollection<Produto> Produto { get; set; }

        public Cliente(string nome, string sobreNome, string email, bool ativo)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Email = email;
            DataCadastro = DateTime.Now;
            Ativo = ativo;
        }

        public void AtualizarCliente(string nome, string sobreNome, string email, bool ativo)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Email = email;
            Ativo = ativo;
            
        }

    }
}
 