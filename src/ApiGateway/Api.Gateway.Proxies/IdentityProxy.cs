using Api.Gateway.Models;
using Api.Gateway.Proxies.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Api.Gateway.Proxies
{
    public class IdentityProxy : IIdentityProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;


        public IdentityProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient)
        {
            _apiUrls = apiUrls.Value;
            _httpClient = httpClient;
        }


        public async Task<string?> IniciarSesion(User user)
        {
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await _httpClient.PostAsync(_apiUrls.IdentityUrl + "autenticacion/IniciarSesion", content);
            request.EnsureSuccessStatusCode();

            var sss = await request.Content.ReadAsStringAsync();

            return sss;
        }

        public async Task<string?> Registrar(User user)
        {
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await _httpClient.PostAsync(_apiUrls.IdentityUrl + "autenticacion/Registrar", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<string>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }


    }
}
