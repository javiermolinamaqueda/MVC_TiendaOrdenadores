using MVC_ComponenteCodeFirst.Models;

namespace MVC_ComponenteCodeFirst.Services
{
    public interface IRepositorioComponente
    {
        Task Add(Componente componente);
        Task Delete(int Id);
        Task<List<Componente>?> GetAll();
        Task<List<Componente>?> GetByNull();
        Task<Componente?> Find(int Id);
        //List<Componente> GetAllByOrdenadorId(int ordenadorId);

        Task Update(int Id, Componente componente);
        Task UpdateOrdenadorId(int id, int? OrdenadorId);
    }
}
