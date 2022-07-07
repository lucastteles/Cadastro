using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cadastro.Domain.Entidade;
using Cadastro.Infra.Context;
using Cadastro.Application.Interface;
using Cadastro.Application.ViewModel;

namespace Cadastro.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoApplication _produtoApplication;
        private readonly IClienteApplication _clienteApplication;

        public ProdutoController(IProdutoApplication produtoApplication, IClienteApplication clienteApplication)
        {
            _produtoApplication = produtoApplication;
            _clienteApplication = clienteApplication;
        }


        public async Task<IActionResult> Index()
        {
            var produto = await _produtoApplication.ObterTodosOsProdutos();

            return View(produto);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoApplication.ObterProdutoPorId(id);

            return View(produto);
        }


        public async Task<IActionResult> Create()
        {
            var clientes = await _clienteApplication.ObterTodosClientes();

            ViewBag.clientes = clientes.Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.ClienteId.ToString() })
                .ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoVm)
        {
            await _produtoApplication.AdicionarProduto(produtoVm);

            return View(produtoVm);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var clientes = await _clienteApplication.ObterTodosClientes();

            ViewBag.clientes = clientes.Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.ClienteId.ToString() })
               .ToList();

            var produto = await _produtoApplication.ObterProdutoPorId(id);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProdutoViewModel produtoVM)
        {
            await _produtoApplication.AtualizarProduto(produtoVM);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoApplication.ObterProdutoPorId(id);
            return View(produto);

        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _produtoApplication.DeletarProduto(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
