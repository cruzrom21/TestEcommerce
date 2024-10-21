using Api.Gateway.Models;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Gateway.Webclient.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProxy _orderProxy;

        public OrderController(IOrderProxy orderProxy)
        {
            _orderProxy = orderProxy;
        }

        [HttpGet("GetAll")]
        public async Task<List<Order>?> GetAllAsync()
        {
            return await _orderProxy.GetAll();
        }


        [HttpGet("GetById/{id}")]
        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _orderProxy.GetById(id);
        }

        [HttpPost]
        [Route("CrearOrden")]
        public async Task<ActionResult> InsertAsync(CreateOrder order)
        {
            await _orderProxy.Insert(order);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> UpdateAsync(Order order)
        {
            await _orderProxy.Update(order);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _orderProxy.Delete(id);
            return Ok();
        }


        [HttpGet("items/GetAll")]
        public async Task<List<OrderItem>?> GetAllItemAsync()
        {
            return await _orderProxy.GetAllItem();
        }


        [HttpGet("items/GetById/{id}")]
        public async Task<OrderItem?> GetByIdItemAsync(int id)
        {
            return await _orderProxy.GetByIdItem(id);
        }

        [HttpPost]
        [Route("items/insert")]
        public async Task<ActionResult> InsertItemAsync(OrderItem item)
        {
            await _orderProxy.InsertItem(item);
            return Ok();
        }

        [HttpPut]
        [Route("items/Update")]
        public async Task<ActionResult> UpdateItemAsync(OrderItem item)
        {
            await _orderProxy.UpdateItem(item);
            return Ok();
        }


        [HttpDelete("items/Delete/{id}")]
        public async Task<ActionResult> DeleteItemAsync(int id)
        {
            await _orderProxy.DeleteItem(id);
            return Ok();
        }

    }
}
