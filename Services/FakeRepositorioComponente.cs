using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVC_ComponenteCodeFirst.Models;

namespace MVC_ComponenteCodeFirst.Services
{
    public class FakeRepositorioComponente : IRepositorioComponente
    {
        private readonly List<Componente> componenteList;
        public FakeRepositorioComponente()
        {
            componenteList = new()
                {
                new Componente {Id=1, Serie = "567-KKK", Calor = 20, TipoComponente = 0, Cores = 13, Almacenamiento = 0, Precio = 150 },
                new Componente {Id=2, Serie = "587-KOO", Calor = 24, TipoComponente = 0, Cores = 12, Almacenamiento = 0, Precio = 250 },
                new Componente {Id=3, Serie = "569-JKL", Calor = 28, TipoComponente = 0, Cores = 16, Almacenamiento = 0, Precio = 50 },
                new Componente {Id=4, Serie = "564-KKK", Calor = 12, TipoComponente = 0, Cores = 18, Almacenamiento = 0, Precio = 150 },
                new Componente {Id=5, Serie = "5345-KKK", Calor = 23, TipoComponente = 1, Cores = 0, Almacenamiento = 500, Precio = 250 },
                new Componente {Id=6, Serie = "598-PYK", Calor = 10, TipoComponente = 1, Cores = 0, Almacenamiento = 500000, Precio = 50 },
                new Componente {Id=7, Serie = "567-PUK", Calor = 20, TipoComponente = 1, Cores = 0, Almacenamiento = 12000, Precio = 150 },
                new Componente {Id=8, Serie = "545-BSR", Calor = 19, TipoComponente = 1, Cores = 0, Almacenamiento = 1485, Precio = 250 },
                new Componente {Id=9, Serie = "999-KKJD", Calor = 14, TipoComponente = 2, Cores = 0, Almacenamiento = 6000, Precio = 80 },
                new Componente {Id=10, Serie = "309-LCD", Calor = 12, TipoComponente = 2, Cores = 0, Almacenamiento = 7000, Precio = 70 },
                new Componente {Id=11, Serie = "787-MXF", Calor = 23, TipoComponente = 2, Cores = 0, Almacenamiento = 7500, Precio = 40 },
                new Componente {Id=12, Serie = "456-KCD", Calor = 14, TipoComponente = 2, Cores = 0, Almacenamiento = 400, Precio = 60 }
                };
        }
        public async Task Add(Componente componente)
        {
            this.componenteList.Add(componente);
            await Task.FromResult(componente);
        }

        public async Task Delete(int Id)
        {
            var componente = componenteList.Find(x => x.Id == Id);
            if (componente is not null)
            {
                await Task.FromResult(this.componenteList.Remove(componente));
            }
        }

        public async Task<Componente?> Find(int Id)
        {
            return await Task.FromResult(componenteList.First(x=> x.Id == Id));
        }

        public async Task<List<Componente>?> GetAll()
        {
            return await Task.FromResult( this.componenteList);
        }

        public async Task<List<Componente>?> GetByNull()
        {
            var componentes = await this.GetAll();
            return componentes?.Where(x=>x.OrdenadorId == null).ToList();
        }

        public async Task Update(int Id, Componente componente)
        {
            var componenteAntiguo = await this.Find(Id);
            if (componenteAntiguo is not null && Id==componente.Id)
            {
                int index = componenteList.IndexOf(componenteAntiguo);
                componenteList[index] = componente;
            }
            
        }

        public async Task UpdateOrdenadorId(int id, int? ordenadorId)
        {
            var componente = await this.Find(id);

            if(componente != null)
            {
                componente.OrdenadorId = ordenadorId;
                await this.Update(id, componente);

            }
        }
    }
}
