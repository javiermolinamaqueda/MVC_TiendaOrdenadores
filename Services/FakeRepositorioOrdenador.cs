using MVC_ComponenteCodeFirst.Models;
using Newtonsoft.Json.Converters;

namespace MVC_ComponenteCodeFirst.Services
{
    public class FakeRepositorioOrdenador : IRepositorioOrdenador
    {
        private readonly List<Ordenador> _ordenadorList =
            new()
            {
                new Ordenador() {Id = 1, Name = "Javier"},
                new Ordenador() {Id = 2, Name = "Maria"}
            };

        public async Task Add(Ordenador ordenador)
        {
            this._ordenadorList.Add(ordenador);
            await Task.FromResult(ordenador);
        }

        public async Task Delete(int Id)
        {
            var ordenador = _ordenadorList.Find(x => x.Id == Id);
            if (ordenador is not null)
            {
                await Task.FromResult(this._ordenadorList.Remove(ordenador));
            }
        }

        public async Task<Ordenador?> Find(int Id)
        {
            return await Task.FromResult(_ordenadorList.First(x => x.Id == Id));
        }

        public async Task<List<Ordenador>> GetAll()
        {
            return await Task.FromResult(this._ordenadorList);
        }

        public async Task<List<Ordenador>?> GetByNull()
        {
            var ordenadores = await this.GetAll();
            return ordenadores?.Where(x => x.PedidoId == null).ToList();
        }

        public async Task Update(int Id, Ordenador ordenador)
        {
            var ordenadorAntiguo = await this.Find(Id);
            if (ordenadorAntiguo is not null && Id == ordenador.Id)
            {
                int index = _ordenadorList.IndexOf(ordenadorAntiguo);
                _ordenadorList[index] = ordenador;
            }

        }

        public async Task UpdatePedidoId(int id, int? pedidoId)
        {
            var ordenador = await this.Find(id);

            if (ordenador != null)
            {
                ordenador.PedidoId = pedidoId;
                await this.Update(id, ordenador);

            }

        }
    }
}
