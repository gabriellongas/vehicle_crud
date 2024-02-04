using CRUD_Veiculos.Web.API.Interface;
using CRUD_Veiculos.Web.Models;
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

        public Task<int> Create(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Veiculo> GetAll()
        {
            try
            {
                string uri = _configuration["ApiSettings:ApiURL"];

                HttpClient client = new HttpClient() { BaseAddress = new Uri(uri) };
                HttpRequestMessage request = new(HttpMethod.Get, "api/Veiculos/GetVeiculos");

                HttpResponseMessage response = client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();

                string jsonContent = response.Content.ReadAsStringAsync().Result;

                List<Veiculo> veiculos = JsonSerializer.Deserialize<List<Veiculo>>(jsonContent, _options);
                return veiculos;
            }
            catch (Exception ex)
            {
                File.AppendAllLines("log.txt", new List<string> { ex.Message });
                throw;
            }
        }

        public Task<IEnumerable<Veiculo>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }
    }
}
