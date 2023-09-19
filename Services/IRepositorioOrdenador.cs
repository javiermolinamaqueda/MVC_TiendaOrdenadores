using MVC_ComponenteCodeFirst.Models;

namespace MVC_ComponenteCodeFirst.Services
{
    public interface IRepositorioOrdenador
    {
        Task<List<Ordenador>> GetAll();
        Task<List<Ordenador>?> GetByNull();
        Task Add(Ordenador ordenador);
        Task Delete(int Id);
        Task<Ordenador?> Find(int Id);
        Task UpdatePedidoId(int id, int? pedidoId);

        Task Update(int Id, Ordenador ordenador);
    }
}
