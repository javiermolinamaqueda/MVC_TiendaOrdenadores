using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_ComponenteCodeFirst.Data;
using MVC_ComponenteCodeFirst.Models;
using MVC_ComponenteCodeFirst.Services;

namespace MVC_ComponenteCodeFirst.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IRepositorioOrdenador _repositorioOrdenador;
        private readonly IRepositorioPedido _repositorioPedido;

        public PedidosController(IRepositorioPedido repositorioPedido,IRepositorioOrdenador repositorioOrdenador)
        {
            _repositorioOrdenador = repositorioOrdenador;
            _repositorioPedido = repositorioPedido;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            return View("Index", await _repositorioPedido.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            var pedido = await _repositorioPedido.Find(id);
            return pedido == null ? View("Index") : View("Details", pedido);
        }

        public async Task<IActionResult> Add(int id)
        {
            ViewData["OrdenadorId"] = new SelectList(await _repositorioOrdenador.GetByNull(), "Id", "Name");
            ViewData["PedidoId"] = id;
            return View("Add");
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Pedido pedido)
        {
            try 
            {
                await _repositorioPedido.Add(pedido);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(pedido);
            }
            
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await _repositorioPedido.Find(id);
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repositorioPedido.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
