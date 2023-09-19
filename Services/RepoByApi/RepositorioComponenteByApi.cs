using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVC_ComponenteCodeFirst.Models;
using Newtonsoft.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace MVC_ComponenteCodeFirst.Services.RepoByApi
{
    public class RepositorioComponenteByApi : IRepositorioComponente
    {
        private readonly HttpClient _httpClient;
        private readonly string rutaBaseAzure = "https://webapi1509.azurewebsites.net/api/Componentes/";
        private readonly string rutaBaseLocal = "https://localhost:7040/Api/Componentes/";
        public RepositorioComponenteByApi(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task Add(Componente componente)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(componente), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync(rutaBaseAzure+"Create", content);
        }

        public async Task Delete(int Id)
        {
            using var response = await _httpClient.DeleteAsync(rutaBaseAzure +$"{Id}");
        }

        public async Task<Componente?> Find(int id)
        {
            Componente? componente = new Componente();
            using (var response = await _httpClient.GetAsync(rutaBaseAzure + $"GetComponente{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                componente = JsonConvert.DeserializeObject<Componente>(apiResponse);
            }
            return componente;
        }

        public async Task<List<Componente>?> GetAll()
        {
            List<Componente>? lista = new List<Componente>();

            using (var response = await _httpClient.GetAsync(rutaBaseAzure + "GetAll"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Componente>>(apiResponse);
            }
            return lista;
        }

        public async Task<List<Componente>?> GetByNull()
        {
            List<Componente>? lista = new List<Componente>();

            using (var response = await _httpClient.GetAsync(rutaBaseAzure + "GetByNull"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Componente>>(apiResponse);
            }
            return lista;
        }

        public async Task Update(int Id, Componente componente)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(componente), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PutAsync(rutaBaseAzure +$"{Id}", content);
        }

        public async Task UpdateOrdenadorId(int id, int? OrdenadorId)
        {
            if(OrdenadorId == null)
            {
                using var response = await _httpClient.GetAsync(rutaBaseAzure + $"UpdateOrdenadorId{id}");

            }
            else
            {
                using var response = await _httpClient.GetAsync(rutaBaseAzure + $"UpdateOrdenadorId{id}/{OrdenadorId}");

            }
        }
    }
}
