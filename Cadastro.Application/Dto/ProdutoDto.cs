using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Dto
{
    public class ProdutoDto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public string ClienteNome { get; set; }
        public int ClienteId { get; set; }
    }
}
