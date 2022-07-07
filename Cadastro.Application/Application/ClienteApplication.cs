
using Cadastro.Application.Dto;
using Cadastro.Application.Interface;
using Cadastro.Application.ViewModel;
using Cadastro.Domain.Entidade;
using Cadastro.Domain.Repositories;
using Cadastro.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Application
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteApplication(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task AdicionarCliente(ClienteViewModel clienteVM)
        {
            var cliente = new Cliente(clienteVM.Nome, clienteVM.SobreNome, clienteVM.Email, clienteVM.Ativo);

            await _clienteRepository.AdicionarCliente(cliente);
        }

        public async Task AtualizarCliente(ClienteViewModel clienteVM)
        {
            var cliente = await _clienteRepository.ObterClientePorId(clienteVM.ClienteId);


            cliente.AtualizarCliente(clienteVM.Nome, clienteVM.SobreNome, clienteVM.Email, clienteVM.Ativo);

            await _clienteRepository.AtualizarCliente(cliente);
        }

        public async Task DeletarCliente(int idCliente)
        {
            await _clienteRepository.Deletar(idCliente);
        }

        public async Task<ClienteDto> ObterClientePorId(int idProduto)
        {
            var cliente = await _clienteRepository.ObterClientePorId(idProduto);

            var clienteDto = new ClienteDto()
            {
                Email = cliente.Email,
                SobreNome = cliente.SobreNome,
                Nome = cliente.Nome,
                ClienteId = cliente.IdCliente,
                Ativo = cliente.Ativo,
                DataCadastro = cliente.DataCadastro
            };

            return clienteDto;
        }

        public async Task<List<ClienteDto>> ObterTodosClientes()
        {
            var clientes = await _clienteRepository.ObterTodosOsClientes();

            var listaClientes = new List<ClienteDto>();

            foreach (var cliente in clientes)
            {
                var clienteDto = new ClienteDto()
                {
                    Email = cliente.Email,
                    SobreNome = cliente.SobreNome,
                    Nome = cliente.Nome,
                    ClienteId = cliente.IdCliente,
                    Ativo = cliente.Ativo,
                    DataCadastro = cliente.DataCadastro
                };

                listaClientes.Add(clienteDto);
            }

            return listaClientes;
        }
    }
}
