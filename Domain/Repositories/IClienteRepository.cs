using Cadastro.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task AdicionarCliente(Cliente cliente);
        Task AtualizarCliente(Cliente cliente);
        Task<Cliente> ObterClientePorId(int Idcliente);
        Task<List<Cliente>> ObterTodosOsClientes();
        public Task Deletar(int Idcliente); 
    }
}
