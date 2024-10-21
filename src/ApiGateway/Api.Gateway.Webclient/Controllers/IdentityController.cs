using Api.Gateway.Models;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Gateway.Webclient.Controllers
{
    [ApiController]
    [Route("autenticacion")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityProxy _identityProxy;

        public IdentityController(IIdentityProxy identityProxy)
        {
            _identityProxy = identityProxy;
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public async Task<string?> IniciarSesion(User user)
        {
            return await _identityProxy.IniciarSesion(user);
        }


        [HttpPost]
        [Route("Registrar")]
        public async Task<string?> Registrar(User user)
        {
            return await _identityProxy.Registrar(user);
        }








    }
}
