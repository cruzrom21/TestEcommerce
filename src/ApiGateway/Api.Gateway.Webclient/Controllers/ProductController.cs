using Api.Gateway.Models;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Gateway.Webclient.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly ICatalogProxy _catalogProxy;

        public ProductController(ICatalogProxy catalogProxy)
        {
            _catalogProxy = catalogProxy;
        }

        [HttpGet("GetAll")]
        public async Task<List<Product>?> GetAllAsync()
        {
            return await _catalogProxy.GetAll();
        }


        [HttpGet("GetById/{id}")]
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _catalogProxy.GetById(id);
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<ActionResult> InsertAsync(Product product)
        {
            await _catalogProxy.Insert(product);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> UpdateAsync(ProductDTO product)
        {
            await _catalogProxy.Update(product);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateStock")]
        public async Task<ActionResult> UpdateStockAsync(List<UpdateStock> product)
        {
            await _catalogProxy.UpdateStock(product);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            await _catalogProxy.Delete(id);
            return Ok();
        }

    }
}
