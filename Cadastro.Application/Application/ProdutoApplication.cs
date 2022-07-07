
using Cadastro.Application.Dto;
using Cadastro.Application.Interface;
using Cadastro.Application.ViewModel;
using Cadastro.Domain.Entidade;
using Cadastro.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Application
{
    public class ProdutoApplication : IProdutoApplication
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoApplication(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task AdicionarProduto(ProdutoViewModel produtoVM)
        {
            var produto = new Produto(produtoVM.Nome, produtoVM.Valor, produtoVM.Disponivel, produtoVM.ClienteId);

            await _produtoRepository.AdicionarProduto(produto);
        }

        public async Task AtualizarProduto(ProdutoViewModel produtoVM)
        {
            var produto = await _produtoRepository.ObterProdutoPorId(produtoVM.IdProduto);


            produto.AtualizarProduto(produtoVM.Nome, produtoVM.Valor, produtoVM.Disponivel, produtoVM.ClienteId);
            
            await _produtoRepository.AtualizarProduto(produto);
        }

        public async Task DeletarProduto(int idProduto)
        {
            await _produtoRepository.Deletar(idProduto);
        }

        public async Task<ProdutoDto> ObterProdutoPorId(int idProduto)
        {
            var produto = await _produtoRepository.ObterProdutoPorId(idProduto);

            var produtoDto = new ProdutoDto()
            {
              Disponivel = produto.Disponivel,
              Valor = produto.Valor,
              Nome = produto.Nome,
              IdProduto = produto.IdProduto,
              ClienteNome = produto.Cliente.Nome,
              ClienteId  = produto.IdCliente              
            };

            return produtoDto;
        }

        public async Task<List<ProdutoDto>> ObterTodosOsProdutos()
        {
            var produtos = await _produtoRepository.ObterTodosOsProdutos();

            var listaProdutos = new List<ProdutoDto>();

            foreach (var produto in produtos)
            {
                var produtoDto = new ProdutoDto()
                {
                    Disponivel = produto.Disponivel,
                    Valor = produto.Valor,
                    Nome = produto.Nome,
                    IdProduto = produto.IdProduto,
                    ClienteNome = produto.Cliente.Nome
                };

                listaProdutos.Add(produtoDto);
            }

            return listaProdutos;
        }
    }
}
