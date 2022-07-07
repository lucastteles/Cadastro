using Cadastro.Domain.Entidade;
using Cadastro.Domain.Repositories;
using Cadastro.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CadastroContext _cadastroContext;

        public ClienteRepository(CadastroContext cadastroContext)
        {
            _cadastroContext = cadastroContext;
        }

        public async Task AdicionarCliente(Cliente cliente)
        {
           await _cadastroContext.Cliente.AddAsync(cliente);
            _cadastroContext.SaveChanges();
        }

        public async Task AtualizarCliente(Cliente cliente)
        {
            _cadastroContext.Cliente.Update(cliente);
            _cadastroContext.SaveChanges();
        }

        public async Task Deletar(int Idcliente)
        {
            var cliente = await ObterClientePorId(Idcliente);
            _cadastroContext.Cliente.Remove(cliente);
            _cadastroContext.SaveChanges();
        }

        public async Task<Cliente> ObterClientePorId(int IdCliente)
        {
            return await _cadastroContext.Cliente.FirstOrDefaultAsync(x => x.IdCliente == IdCliente);
        }

        public async Task<List<Cliente>> ObterTodosOsClientes()
        {
            return await _cadastroContext.Cliente.ToListAsync();
        }
    }
}
