using Microsoft.EntityFrameworkCore;
using MVC_ComponenteCodeFirst.Data;
using MVC_ComponenteCodeFirst.Models;

namespace MVC_ComponenteCodeFirst.Services
{
    public class RepositorioPedido : IRepositorioPedido
    {
        private readonly TiendaContext _context;
        public RepositorioPedido(TiendaContext context)
        {
            _context = context;
        }
        public async Task Add(Pedido pedido)
        {
            await Task.FromResult(_context.Pedidos.Add(pedido));
            _context.SaveChanges();
        }

        public async Task Delete(int Id)
        {
            var pedido = this._context.Pedidos.Find(Id);
            if (pedido is not null)
            {
                await Task.FromResult(_context.Pedidos.Remove(pedido));
                _context.SaveChanges();
            }
        }

        public async Task<Pedido?> Find(int Id)
        {
            return await Task.FromResult(
                _context.Pedidos
                .Include(c=>c.Ordenadores)
                .ThenInclude(c=>c.Componentes)
                .Where(p=>p.Id == Id)
                .FirstOrDefault()
                );
        }

        public async Task<List<Pedido>> GetAll()
        {
            return await Task.FromResult(
                this._context.Pedidos
                .Include(p => p.Ordenadores)
                .AsNoTracking()
                .ToList()
                );
        }
    }
}
