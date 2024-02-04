using CRUD_Veiculos.Web.API.Interface;
using CRUD_Veiculos.Web.Models;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Radar.Web.Api
{
    public class ApiClient : IApiClient
    {
        private static readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };
        private IConfiguration _configuration;
        public ApiClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Create(Veiculo veiculo)
        {
            try
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri(_configuration["ApiSettings:ApiURL"]) };
                HttpRequestMessage request = new(HttpMethod.Post, "api/Veiculos/CreateVeiculo");
                request.Content = new StringContent(JsonSerializer.Serialize(veiculo), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();

                string jsonContent = response.Content.ReadAsStringAsync().Result;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri(_configuration["ApiSettings:ApiURL"]) };
                HttpRequestMessage request = new(HttpMethod.Delete, $"api/Veiculos/DeleteVeiculo/{id}");
                request.Content = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();

                string jsonContent = response.Content.ReadAsStringAsync().Result;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Veiculo> GetAll()
        {
            try
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri(_configuration["ApiSettings:ApiURL"]) };
                HttpRequestMessage request = new(HttpMethod.Get, "api/Veiculos/GetVeiculos");

                HttpResponseMessage response = client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();

                string jsonContent = response.Content.ReadAsStringAsync().Result;

                List<Veiculo> veiculos = JsonSerializer.Deserialize<List<Veiculo>>(jsonContent, _options);
                return veiculos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Veiculo GetById(int id)
        {
            try
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri(_configuration["ApiSettings:ApiURL"]) };
                HttpRequestMessage request = new(HttpMethod.Get, $"/api/Veiculos/GetVeiculoById/{id}");
                request.Content = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();

                string jsonContent = response.Content.ReadAsStringAsync().Result;

                List<Veiculo> veiculo = JsonSerializer.Deserialize<List<Veiculo>>(jsonContent, _options);
                return veiculo.FirstOrDefault<Veiculo>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(Veiculo veiculo)
        {
            try
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri(_configuration["ApiSettings:ApiURL"]) };
                HttpRequestMessage request = new(HttpMethod.Put, "api/Veiculos/UpdateVeiculo");
                request.Content = new StringContent(JsonSerializer.Serialize(veiculo), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();

                string jsonContent = response.Content.ReadAsStringAsync().Result;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
