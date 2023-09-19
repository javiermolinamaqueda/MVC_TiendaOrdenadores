using MVC_ComponenteCodeFirst.Controllers;
using MVC_ComponenteCodeFirst.Models;
using Newtonsoft.Json;
using System.Text;

namespace MVC_ComponenteCodeFirst.Services.RepoCola
{
    public class RepositorioComponenteCola
    {
        public Task Add(Componente componente)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Componente?> Find(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task GetAll()
        {
            Cola cola = new Cola();
            Message message = new Message(){ Controlador = "Componentes", Method = "GetAll" };
            string msgString = JsonConvert.SerializeObject(message);
            await cola.InsertMessageAsync(msgString);
        }

        public Task<List<Componente>?> GetByNull()
        {
            throw new NotImplementedException();
        }

        public Task Update(int Id, Componente componente)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrdenadorId(int id, int? OrdenadorId)
        {
            throw new NotImplementedException();
        }

        public class Message
        {
            public string Controlador { get; set; } = "";
            public string Method { get; set; } = "";
        }
    }
}
