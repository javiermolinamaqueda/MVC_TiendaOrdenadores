using MVC_ComponenteCodeFirst.Models;

namespace MVC_ComponenteCodeFirst.Services
{
    public class FakeRepositorioPedido : IRepositorioPedido
    {
        private readonly List<Pedido> pedidos;

        public FakeRepositorioPedido()
        {
            pedidos = new()
            {
                new Pedido { Id = 1 },
                new Pedido { Id = 2 }
            };
        }
        public async Task Add(Pedido pedido)
        {
            this.pedidos.Add(pedido);
            await Task.FromResult(pedido);
        }

        public async Task Delete(int Id)
        {
            var pedido = this.pedidos.Find(x => x.Id == Id);
            if (pedido is not null)
            {
                await Task.FromResult(this.pedidos.Remove(pedido));
            }

        }

        public async Task<Pedido?> Find(int Id)
        {
            return await Task.FromResult(this.pedidos.First(x => x.Id == Id));
        }

        public async Task<List<Pedido>> GetAll()
        {
            return await Task.FromResult(this.pedidos);
        }
    }
}
