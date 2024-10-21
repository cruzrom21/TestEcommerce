using Microsoft.Extensions.Options;
using Order.Domain;
using Order.Services.Proxies.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Order.Services.Proxies.Catalog
{
    public class CatalogProxy : ICatalogProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public CatalogProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient)
        {
            _apiUrls = apiUrls.Value;
            _httpClient = httpClient;
        }

        public class ProductUpdate
        {
            public int ProductId { get; set; }
            public int Stock { get; set; }
        }

        public async Task UpdateStock(List<OrderItem> listItems)
        {
            var productUpdate = new List<ProductUpdate>();

            foreach (var item in listItems)
            {
                productUpdate.Add(new ProductUpdate
                {
                    ProductId = item.ProductId,
                    Stock = item.Quantity
                });
            }

            var json = JsonSerializer.Serialize(productUpdate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await _httpClient.PutAsync(_apiUrls.CatalogUrl + "products/UpdateStock", content);

            request.EnsureSuccessStatusCode();
        }
    }
}
