using MVC_ComponenteCodeFirst.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MVC_ComponenteCodeFirst.Services.RepoByApi
{
    public class RepositorioOrdenadorByApi : IRepositorioOrdenador
    {
        private readonly HttpClient _httpClient;
        private readonly string rutaBaseAzure = "https://webapi1509.azurewebsites.net/api/Ordenadores/";
        private readonly string rutaBaseLocal = "https://localhost:7040/Api/Ordenadores/";
        public RepositorioOrdenadorByApi(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task Add(Ordenador ordenador)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(ordenador), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync(rutaBaseAzure+"Create", content);
        }

        public async Task Delete(int Id)
        {
            using var response = await _httpClient.DeleteAsync(rutaBaseAzure+$"{Id}");
        }

        public async Task<Ordenador?> Find(int id)
        {
            Ordenador? ordenador = new Ordenador();
            using (var response = await _httpClient.GetAsync(rutaBaseAzure+$"GetOrdenador{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                ordenador = JsonConvert.DeserializeObject<Ordenador>(apiResponse);
            }
            return ordenador;
        }

        public async Task<List<Ordenador>?> GetAll()
        {
            List<Ordenador>? lista = new List<Ordenador>();

            using (var response = await _httpClient.GetAsync(rutaBaseAzure+"GetAll"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Ordenador>>(apiResponse);
            }
            return lista;
        }

        public async Task<List<Ordenador>?> GetByNull()
        {
            List<Ordenador>? lista = new List<Ordenador>();

            using (var response = await _httpClient.GetAsync(rutaBaseAzure+"GetByNull"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Ordenador>>(apiResponse);
            }
            return lista;
        }

        public async Task Update(int Id, Ordenador ordenador)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(ordenador), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PutAsync(rutaBaseAzure+$"{Id}", content);
        }

        public async Task UpdatePedidoId(int id, int? PedidoId)
        {
            //StringContent content = new StringContent(JsonConvert.SerializeObject(new { id = id, PedidoId = PedidoId }), Encoding.UTF8, "application/json");
            using var response = await _httpClient.GetAsync(rutaBaseAzure+$"UpdatePedidoId{id}/{PedidoId}");
        }
    }
}
