
using Cadastro.Application.Dto;
using Cadastro.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Interface
{
    public interface IProdutoApplication
    {
        Task AdicionarProduto(ProdutoViewModel produtoVM);
        Task<List<ProdutoDto>> ObterTodosOsProdutos();
        Task AtualizarProduto(ProdutoViewModel produtoVM);
        Task<ProdutoDto> ObterProdutoPorId(int idProduto);
        Task DeletarProduto(int idProduto);
    }
}
