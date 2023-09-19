using Microsoft.EntityFrameworkCore;
using MVC_ComponenteCodeFirst.Data;
using MVC_ComponenteCodeFirst.Models;
using MVC_ComponenteCodeFirst.Validadores.VOrdenador;
using NuGet.Versioning;
using System.ComponentModel.DataAnnotations;

namespace MVC_ComponenteCodeFirst.Services
{
    public class RepositorioOrdenador : IRepositorioOrdenador
    {
        private readonly TiendaContext _context;
        private readonly IValidadorOrdenador _validadorOrdenador;
        public RepositorioOrdenador(TiendaContext context, IValidadorOrdenador validador)
        {
            _context = context;
            _validadorOrdenador = validador;
        }

        public async Task Add(Ordenador ordenador)
        {
            await Task.FromResult(_context.Ordenadores.Add(ordenador));
            _context.SaveChanges();
        }
        public async Task<List<Ordenador>> GetAll()
        {
            return await Task.FromResult(
                _context.Ordenadores
                .AsNoTracking()
                .Include(p => p.Componentes)
                .ToList()
                );
        }

        public async Task Delete(int Id)
        {
            var ordenador = this._context.Ordenadores.Find(Id);
            if (ordenador is not null)
            {
                await Task.FromResult(_context.Ordenadores.Remove(ordenador));
                _context.SaveChanges();
            }

        }
        public async Task<Ordenador?> Find(int Id)
        {
            var ordenador = await Task.FromResult
                (
                _context.Ordenadores
                .Include(p => p.Componentes)
                .Where(c => c.Id == Id)
                .FirstOrDefault()
                );
            return ordenador;
        }

        public async Task Update(int Id, Ordenador ordenador)
        {
            if (Id == ordenador.Id)
            {
                await Task.FromResult(_context.Update(ordenador));
                _context.SaveChanges();
            }
        }
        public void SumaPrecioPedido(Ordenador ordenador)
        {
            var pedido = _context.Pedidos.Find(ordenador.PedidoId);
            if (pedido != null)
            {
                pedido.Precio += ordenador.Precio;
                _context.Update(pedido);
            }
        }

        public void RestaPrecioPedido(Ordenador ordenador)
        {
            var pedido = _context.Pedidos.Find(ordenador.PedidoId);
            if (pedido != null)
            {
                pedido.Precio -= ordenador.Precio;
                _context.Update(pedido);
            }
        }

        public async Task UpdatePedidoId(int ordenadorId, int? pedidoId)
        {
            var ordenador = await this.Find(ordenadorId);

            if (ordenador != null && _validadorOrdenador.IsValid(ordenador))
            {
                
                if (ordenador.PedidoId == null)
                {
                    ordenador.PedidoId = pedidoId;
                    this.SumaPrecioPedido(ordenador);
                    _context.Update(ordenador);
                    
                }
                else
                {
                    this.RestaPrecioPedido(ordenador);
                    ordenador.PedidoId = null;
                    _context.Update(ordenador);
                }
               
                _context.SaveChanges();

            }
        }

        public async Task<List<Ordenador>?> GetByNull()
        {
            return await Task.FromResult(
                _context.Ordenadores
                .AsNoTracking()
                .Where(o => o.PedidoId == null)
                .ToList()
                );
        }
    }
}
