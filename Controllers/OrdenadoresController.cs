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
using MVC_ComponenteCodeFirst.CrossCuting.Logging;

namespace MVC_ComponenteCodeFirst.Controllers
{
    public class OrdenadoresController : Controller
    {
        private readonly IRepositorioOrdenador _repositorio;
        private readonly ILoggerManager _logger;
        private readonly IRepositorioComponente _repositorioComponente;

        public OrdenadoresController(IRepositorioComponente repositorioComponente,IRepositorioOrdenador repositorio, ILoggerManager loger)
        {
            _repositorio = repositorio;
            _logger = loger;
            _repositorioComponente = repositorioComponente;
        }

        // GET: Ordenadores
        public async Task<IActionResult> Index()
        {
            return View("Index", await _repositorio.GetAll());
        }
        public async Task<IActionResult> Add(int id)
        {
            ViewData["ComponenteId"] = new SelectList(await _repositorioComponente.GetByNull(), "Id", "Descripcion");
            ViewData["OrdenadorId"] = id;
            return View();
        }
        // GET: Ordenadores/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var ordenador = await _repositorio.Find(id);
            return ordenador == null ? View("Index") : View("Details", ordenador) ;
        }

        // GET: Ordenadores/Create
        public IActionResult Create()
        {
            this._logger.LogInfo("Mostrando ventana de creacion de ordenador");
            return View("Create");
        }

        // POST: Ordenadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name")] Ordenador ordenador)
        {
            try
            {
                await _repositorio.Add(ordenador);
                return View("Index", await _repositorio.GetAll());
            }
            catch
            {
                _logger.LogError("No se ha podido crear el ordenador");
                return View("Create");
            }
        }

        // GET: Ordenadores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                return View("Edit", await _repositorio.Find(id));
            }
            catch
            {
                _logger.LogError("No se ha encontrado el componente");
                return View();
            }
        }

        // POST: Ordenadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Ordenador ordenador)
        {
 
            await _repositorio.Update(id, ordenador);
            return View("Index", await _repositorio.GetAll());

        }

        [HttpPost]
        public async Task<IActionResult> EditPedidoId(int Id, int PedidoId)
        {
            await _repositorio.UpdatePedidoId(Id,PedidoId);
            return View("Index", await _repositorio.GetAll());
        }

        public async Task<IActionResult> EditPedidoId(int Id)
        {
            await _repositorio.UpdatePedidoId(Id, null);
            return View("Index", await _repositorio.GetAll());
        }

        // GET: Componentes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var ordenador = await _repositorio.Find(id);
            if (ordenador == null)
            {
                _logger.LogError("No se ha encontrado el ordenador");
                return View("Index", await _repositorio.GetAll());
            }

            return View("Delete", ordenador);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repositorio.Delete(id);
            return View("Index", await _repositorio.GetAll());
        }
    }
}
