using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_ComponenteCodeFirst.Data;
using MVC_ComponenteCodeFirst.Models;
using MVC_ComponenteCodeFirst.Validadores.VComponente;
//using TiendaOrdenadores;
namespace MVC_ComponenteCodeFirst.Services
{
    public class EFRepositorioComponente : IRepositorioComponente
    {
        readonly TiendaContext _context;
        readonly IValidadorComponente _validador;

        public EFRepositorioComponente( TiendaContext context, IValidadorComponente validador)
        {
            this._context = context;
            _validador = validador;
        }
        public async Task  Add (Componente componente)
        {
            if(_validador.IsValid(componente))
            {
                if (componente.OrdenadorId != null)
                {
                    this.SumaPrecioOrdenador(componente);                   
                }
                await Task.FromResult( _context.Componentes.Add(componente));
                _context.SaveChanges();
            }
        }
        

        public async Task<List<Componente>?> GetAll()
        {
            var componentes = _context.Componentes
                .AsNoTracking()
                .Include(c => c.Ordenador);
            //return _context.componentes is not null ? _context.componentes.ToList() : null;
            return await Task.FromResult(componentes?.ToList());
        }

        public async Task<List<Componente>> GetByNull()
        {
            return await Task.FromResult(
                _context.Componentes
                .AsNoTracking()
                .Where(o => o.OrdenadorId == null)
                .ToList()
                );
        }

        public async Task Delete (int Id)
        {
            var componente = this._context.Componentes.Find(Id);
            if(componente is not null)
            {
                await Task.FromResult(_context.Componentes.Remove(componente));
                _context.SaveChanges();
            }
         
        }

        public async Task<Componente?> Find(int Id)
        {
                var componente = await Task.FromResult(_context.Componentes.Find(Id));
                return componente;
        }

        public async Task Update(int Id, Componente componente)
        {
            if(Id == componente.Id && _validador.IsValid(componente))
            {
                await Task.FromResult(_context.Update(componente));
                _context.SaveChanges();
            }
        }
        public async Task UpdateOrdenadorId(int Id, int? OrdenadorId)
        {
            var componente = await this.Find(Id);
            if (componente != null)
            {
                if(componente.OrdenadorId == null)
                {
                    componente.OrdenadorId = OrdenadorId;
                    this.SumaPrecioOrdenador(componente);
                    await this.Update(Id, componente);
                }
                else
                {
                    this.RestaPrecioOrdenador(componente);
                    componente.OrdenadorId = null;
                    await this.Update(Id, componente);
                }
                

            }
        }

        //

        public void SumaPrecioOrdenador(Componente componente)
        {
            var ordenador = _context.Ordenadores.Find(componente.OrdenadorId);
            if (ordenador != null)
            {
                ordenador.Precio += componente.Precio;
                _context.Update(ordenador);
            }
        }

        public void RestaPrecioOrdenador(Componente componente)
        {
            var ordenador = _context.Ordenadores.Find(componente.OrdenadorId);
            if (ordenador != null)
            {
                ordenador.Precio -= componente.Precio;
                _context.Update(ordenador);
            }
        }
    }

}
