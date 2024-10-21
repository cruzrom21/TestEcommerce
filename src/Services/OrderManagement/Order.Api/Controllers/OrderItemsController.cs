using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.Domain;
using Order.Services.Products.Interface;

namespace Order.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("orderItems")]
    public class OrderItemsController : ControllerBase
    {
        private IOrderItemServices _itemsServices;
        private ILogger<OrderItemsController> _logger;

        public OrderItemsController(ILogger<OrderItemsController> logger, IOrderItemServices itemsServices)
        {
            _logger = logger;
            _itemsServices = itemsServices;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<OrderItem>?> GetAll()
        {
            try
            {
                return _itemsServices.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderItemsController => GetAll => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }


        [HttpGet("GetById/{id}")]
        public ActionResult<OrderItem?> GetById(int id)
        {
            try
            {
                return _itemsServices.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderItemsController => GetById => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Route("Insert")]
        public ActionResult<bool> Insert(OrderItem product)
        {
            try
            {
                return _itemsServices.Insert(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderItemsController => Insert => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult<bool> Update(OrderItem product)
        {
            try
            {
                return _itemsServices.Update(product);
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
                return _itemsServices.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderItemsController => Delete => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }
    }
}
