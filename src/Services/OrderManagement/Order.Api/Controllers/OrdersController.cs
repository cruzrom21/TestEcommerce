using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.Domain;
using Order.Services.Products.Interface;

namespace Order.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("order")]
    public class OrdersController : ControllerBase
    {
        private IOrderServices _orderServices;
        private ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger, IOrderServices orderServices)
        {
            _logger = logger;
            _orderServices = orderServices;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Domain.Order>?> GetAll()
        {
            try
            {
                return _orderServices.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderItemsController => GetAll => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }


        [HttpGet("GetById/{id}")]
        public ActionResult<Domain.Order?> GetById(int id)
        {
            try
            {
                return _orderServices.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderItemsController => GetById => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Route("Insert")]
        public ActionResult<bool> Insert(CreateOrder createOrder)
        {
            try
            {
                return _orderServices.Insert(createOrder);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderItemsController => Insert => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult<bool> Update(Domain.Order order)
        {
            try
            {
                return _orderServices.Update(order);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderItemsController => Update => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }

        [HttpDelete("EliminarOferta/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                return _orderServices.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderItemsController => Delete => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }
    }
}
