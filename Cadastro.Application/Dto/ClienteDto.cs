using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Dto
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
