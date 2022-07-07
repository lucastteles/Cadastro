using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Entidade
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        public Produto(string nome, decimal valor, bool disponivel, int idCliente)
        {
            Nome = nome;
            Valor = valor;
            Disponivel = disponivel;
            IdCliente = idCliente;
        }

        public void AtualizarProduto(string nome, decimal valor, bool disponivel, int idCliente)
        {
            Nome = nome;
            Valor = valor;
            Disponivel = disponivel;
            IdCliente = idCliente;
        }
    }


}
