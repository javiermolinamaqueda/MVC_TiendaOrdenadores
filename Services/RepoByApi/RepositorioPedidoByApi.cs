using MVC_ComponenteCodeFirst.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MVC_ComponenteCodeFirst.Services.RepoByApi
{
    public class RepositorioPedidoByApi : IRepositorioPedido
    {
        private readonly HttpClient _httpClient;
        private readonly string rutaBaseAzure = "https://webapi1509.azurewebsites.net/api/Pedidos/";
        private readonly string rutaBaseLocal = "https://localhost:7040/Api/Pedidos/";
        public RepositorioPedidoByApi(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task Add(Pedido pedido)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(pedido), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync(rutaBaseAzure+"Create", content);
        }

        public async Task Delete(int Id)
        {
            using var response = await _httpClient.DeleteAsync(rutaBaseAzure+$"{Id}");
        }

        public async Task<Pedido?> Find(int id)
        {
            Pedido? pedido = new Pedido();
            using (var response = await _httpClient.GetAsync(rutaBaseAzure+$"GetPedido{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                pedido = JsonConvert.DeserializeObject<Pedido>(apiResponse);
            }
            return pedido;
        }

        public async Task<List<Pedido>?> GetAll()
        {
            List<Pedido>? lista = new List<Pedido>();

            using (var response = await _httpClient.GetAsync(rutaBaseAzure+"GetAll"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Pedido>>(apiResponse);
            }
            return lista;
        }
    }
}
