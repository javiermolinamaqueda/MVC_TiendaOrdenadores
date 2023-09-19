using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MVC_ComponenteCodeFirst.CrossCuting.Logging;
using MVC_ComponenteCodeFirst.Data;
using MVC_ComponenteCodeFirst.Models;
using MVC_ComponenteCodeFirst.Services;
using MVC_ComponenteCodeFirst.Services.RepoByApi;
//using TiendaOrdenadores;
//using TiendaOrdenadores;

namespace MVC_ComponenteCodeFirst.Controllers
{
    public class ComponentesController : Controller
    {
        private readonly IRepositorioComponente _repositorio;
        private readonly ILoggerManager _logger;
        private readonly IRepositorioOrdenador _repositorioOrdenador;
        //private readonly IValidadorComponente validador;
        public ComponentesController(IRepositorioComponente repositorio, ILoggerManager logger,
            IRepositorioOrdenador repOrdenador)
        {
            _repositorio = repositorio;
            _logger = logger;
            _repositorioOrdenador = repOrdenador;
        }

        // GET: Componentes
        public async Task<IActionResult> Index()
        {
            _logger.LogInfo("Mostrando todos los componentes");
            var componentes = await _repositorio.GetAll();
            return View("Index", componentes);
        }

        // GET: Componentes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var componente = await _repositorio.Find(id);
            return View("Details", componente);
        }
        public IActionResult CreateByOrdenador(int OrdenadorId)
        {
            ViewData["OrdenadorId"] = OrdenadorId;
            _logger.LogInfo("Mostrando ventana de creacion");
            return View("Create");
        }

        // GET: Componentes/Create
        public async Task<IActionResult> Create()
        {
            ViewData["OrdenadorId"] = new SelectList(await _repositorioOrdenador.GetAll(), "Id", "Name");
            _logger.LogInfo("Mostrando ventana de creacion");
            return View("Create");
        }

        // POST: Componentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoComponente,Descripcion,Serie,Precio,Calor,Almacenamiento,Cores,OrdenadorId")] Componente componente)
        {
            try
            {
                await _repositorio.Add(componente);

                if(componente.OrdenadorId == null) 
                    return View("Index", await _repositorio.GetAll());

                return RedirectToAction("Index", "Ordenadores", _repositorioOrdenador.GetAll());

            }
            catch
            {
                _logger.LogError("No se ha podido crear el componente");
                return View("Create");
            }
        }

        // GET: Componentes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                ViewData["OrdenadorId"] = new SelectList(await _repositorioOrdenador.GetAll(), "Id", "Name");
                return View("Edit", await _repositorio.Find(id));
            }
            catch
            {
                _logger.LogError("No se ha encontrado el componente");
                return View();
            }
        }


        // POST: Componentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoComponente,Descripcion,Serie,Precio,Calor,Almacenamiento,Cores,OrdenadorId")] Componente componente)
        {
            await _repositorio.Update(id, componente);
            return View ("Index",await _repositorio.GetAll());
            
        }

        [HttpPost]
        public async Task<IActionResult> EditOrdenadorId(int Id, int OrdenadorId)
        {
            await _repositorio.UpdateOrdenadorId(Id, OrdenadorId);
            return RedirectToAction("Index", "Ordenadores", _repositorioOrdenador.GetAll());
        }

        public async Task<IActionResult> EditOrdenadorId(int Id)
        {
            await _repositorio.UpdateOrdenadorId(Id, null);
            return RedirectToAction("Index", "Ordenadores", _repositorioOrdenador.GetAll());
        }

        // GET: Componentes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var componente = await _repositorio.Find(id);
            if (componente == null)
            {
                _logger.LogError("No se ha encontrado el componente");
                return View("Index",await _repositorio.GetAll());
            }

            return View("Delete",componente);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repositorio.Delete(id);
            return View("Index", await _repositorio.GetAll());
        }

        //private bool ComponenteExists(int id)
        //{
        //  return (_context.componentes?.Any(e => e.ID == id)).GetValueOrDefault();
        //}
    }
}
