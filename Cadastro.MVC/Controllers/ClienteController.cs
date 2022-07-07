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
    public class ClienteController : Controller
    {
        private readonly IClienteApplication _clienteApplication;

        public ClienteController(IClienteApplication clienteApplication)
        {
            _clienteApplication = clienteApplication;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteApplication.ObterTodosClientes();

            return View(clientes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _clienteApplication.ObterClientePorId(id);

            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteVm)
        {
            await _clienteApplication.AdicionarCliente(clienteVm);

            return View(clienteVm);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clienteApplication.ObterClientePorId(id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClienteViewModel clienteVm)
        {
            await _clienteApplication.AtualizarCliente(clienteVm);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteApplication.ObterClientePorId(id);
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clienteApplication.DeletarCliente(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
