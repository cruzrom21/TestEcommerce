using Catalog.Domain;
using Catalog.Services.Products;
using Catalog.Services.Products.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private IProductServices _productServices;
        private ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Product>?> GetAll()
        {
            try
            {
                return _productServices.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductsController => GetAll => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }


        [HttpGet("GetById/{id}")]
        public ActionResult<Product?> GetById(int id)
        {
            try
            {
                return _productServices.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductsController => GetById => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Route("Insert")]
        public ActionResult<bool> Insert(Product product)
        {
            try
            {
                return _productServices.Insert(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductsController => Insert => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult<bool> Update(ProductDTO product)
        {
            try
            {
                return _productServices.Update(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductsController => Update => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("UpdateStock")]
        public ActionResult<bool> UpdateStock(List<UpdateStock> product)
        {
            try
            {
                return _productServices.UpdateStock(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductsController => UpdateStock => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                return _productServices.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductsController => Delete => Error => {ex.Message}");
                return new BadRequestObjectResult(new { state = false, message = ex.Message });
            }
        }

    }
}
