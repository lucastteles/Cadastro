using Cadastro.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task AdicionarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task<Produto> ObterProdutoPorId(int idProduto);
        Task<List<Produto>> ObterTodosOsProdutos();
        public Task Deletar(int idProduto);
    }
}
