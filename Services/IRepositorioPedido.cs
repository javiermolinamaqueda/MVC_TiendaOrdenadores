using MVC_ComponenteCodeFirst.Models;

namespace MVC_ComponenteCodeFirst.Services
{
    public interface IRepositorioPedido
    {
        Task<List<Pedido>> GetAll();
        //List<Ordenador> GetByNull();
        Task Add(Pedido pedido);
        Task Delete(int Id);
        Task<Pedido?> Find(int Id);
        //void UpdateFacturaId(int id, int pedidoId);

        //void Update(int Id, Ordenador ordenador);
    }
}
