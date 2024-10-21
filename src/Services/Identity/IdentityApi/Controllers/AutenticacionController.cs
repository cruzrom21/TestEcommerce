using Identity.Autentication.Interface;
using Identity.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("autenticacion")]
    public class AutenticacionController : ControllerBase
    {
        private IAutenticacionServices _AutenticacionServices;
        private ILogger<AutenticacionController> _logger;

        public AutenticacionController(ILogger<AutenticacionController> logger, IAutenticacionServices autenticacionServices)
        {
            _logger = logger;
            _AutenticacionServices = autenticacionServices;
        }


        [HttpPost]
        [Route("IniciarSesion")]
        public ActionResult<string> IniciarSesion(User user)
        {
            try
            {
                return _AutenticacionServices.InicioSesion(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AutenticacionController => IniciarSesion => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
            
        }


        [HttpPost]
        [Route("Registrar")]
        public ActionResult<string> Registrar(User user)
        {
            try
            {
                return _AutenticacionServices.Registrar(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AutenticacionController => Registrar => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }


    }
}
