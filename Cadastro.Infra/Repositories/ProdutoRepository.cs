


using Cadastro.Domain.Entidade;
using Cadastro.Domain.Repositories;
using Cadastro.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Repo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CadastroContext _cadastroContext;

        public ProdutoRepository(CadastroContext cadastroContext)
        {
            _cadastroContext = cadastroContext;
        }

        public async Task AdicionarProduto(Produto produto)
        {
            await _cadastroContext.Produto.AddAsync(produto);
            _cadastroContext.SaveChanges();
        }

        public async Task AtualizarProduto(Produto produto)
        {
            _cadastroContext.Produto.Update(produto);
            _cadastroContext.SaveChanges();
        }

        public async Task Deletar(int idProduto)
        {
            var produto = await ObterProdutoPorId(idProduto);
            _cadastroContext.Produto.Remove(produto);
            _cadastroContext.SaveChanges();
        }

        public async Task<Produto> ObterProdutoPorId(int idProduto)
        {
            return await _cadastroContext.Produto.Include(x => x.Cliente).FirstOrDefaultAsync(x => x.IdProduto == idProduto);
        }

        public async Task<List<Produto>> ObterTodosOsProdutos()
        {
            return await _cadastroContext.Produto.Include(x => x.Cliente).ToListAsync();
        }


    }
}
