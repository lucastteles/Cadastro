
using Cadastro.Application.Dto;
using Cadastro.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Interface
{
    public interface IClienteApplication
    {
        Task AdicionarCliente(ClienteViewModel clienteVM);
        Task<List<ClienteDto>> ObterTodosClientes();
        Task AtualizarCliente(ClienteViewModel clienteVM);
        Task<ClienteDto> ObterClientePorId(int IdCliente);
        Task DeletarCliente(int IdCliente);
    }
}
