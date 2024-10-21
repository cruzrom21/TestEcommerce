using Api.Gateway.Models;
using Api.Gateway.Proxies.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace Api.Gateway.Proxies
{
    public class OrderProxy : IOrderProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;


        public OrderProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _apiUrls = apiUrls.Value;
            _httpClient = httpClient;
        }

        // Orden
        public async Task<List<Order>?> GetAll()
        {
            var request = await _httpClient.GetAsync(_apiUrls.OrderUrl + "order/GetAll");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<Order>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }


        public async Task<Order?> GetById(int id)
        {
            var request = await _httpClient.GetAsync(_apiUrls.OrderUrl + "order/GetById/" + id);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Order>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task Insert(CreateOrder order)
        {
            var json = JsonSerializer.Serialize(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await _httpClient.PostAsync(_apiUrls.OrderUrl + "order/Insert", content);
            request.EnsureSuccessStatusCode();
        }


        public async Task Update(Order order)
        {
            var json = JsonSerializer.Serialize(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await _httpClient.PutAsync(_apiUrls.OrderUrl + "order/Update", content);
            request.EnsureSuccessStatusCode();
        }


        public async Task Delete(int id)
        {
            var request = await _httpClient.DeleteAsync(_apiUrls.OrderUrl + "order/Delete/" + id);
            request.EnsureSuccessStatusCode();
        }





        // Items
        public async Task<List<OrderItem>?> GetAllItem()
        {
            var request = await _httpClient.GetAsync(_apiUrls.OrderUrl + "orderItems/GetAll");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<OrderItem>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }


        public async Task<OrderItem?> GetByIdItem(int id)
        {
            var request = await _httpClient.GetAsync(_apiUrls.OrderUrl + "orderItems/GetById/" + id);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<OrderItem>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task InsertItem(OrderItem item)
        {
            var json = JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await _httpClient.PostAsync(_apiUrls.OrderUrl + "orderItems/Insert", content);
            request.EnsureSuccessStatusCode();
        }


        public async Task UpdateItem(OrderItem item)
        {
            var json = JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await _httpClient.PutAsync(_apiUrls.OrderUrl + "orderItems/Update", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task DeleteItem(int id)
        {
            var request = await _httpClient.DeleteAsync(_apiUrls.OrderUrl + "orderItems/Delete/" + id);
            request.EnsureSuccessStatusCode();
        }
    }
}
