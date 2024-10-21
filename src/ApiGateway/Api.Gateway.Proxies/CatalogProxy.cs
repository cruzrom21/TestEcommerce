using Api.Gateway.Models;
using Api.Gateway.Proxies.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Api.Gateway.Proxies
{
    public class CatalogProxy : ICatalogProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;


        public CatalogProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _apiUrls = apiUrls.Value;
            _httpClient = httpClient;
        }


        public async Task<List<Product>?> GetAll()
        {
            var request = await _httpClient.GetAsync(_apiUrls.CatalogUrl + "products/GetAll");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<Product>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<Product?> GetById(int id)
        {
            var request = await _httpClient.GetAsync(_apiUrls.CatalogUrl + "products/GetById/" + id);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Product>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task Insert(Product product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await _httpClient.PostAsync(_apiUrls.CatalogUrl + "products/Insert", content);
            request.EnsureSuccessStatusCode();
        }


        public async Task Update(ProductDTO product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await _httpClient.PutAsync(_apiUrls.CatalogUrl + "products/Update", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task UpdateStock(List<UpdateStock> productUpdate)
        {
            var json = JsonSerializer.Serialize(productUpdate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await _httpClient.PutAsync(_apiUrls.CatalogUrl + "products/UpdateStock", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var request = await _httpClient.DeleteAsync(_apiUrls.CatalogUrl + "products/Delete/" + id);
            request.EnsureSuccessStatusCode();
        }
    }
}
