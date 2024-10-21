
using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Persistence.Repository;
using Catalog.Services.Products.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace Catalog.Services.Products
{
    public class ProductServices : IProductServices
    {
        private ProductDbContext _db;
        private IRepository<Product> _repository;
        private ILogger<ProductServices> _logger;

        public ProductServices(ProductDbContext dbContext, IRepository<Product> repository, ILogger<ProductServices> logger)
        {
            _db = dbContext;
            _repository = repository;
            _logger = logger;
        }

        public Product? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Product>? GetAll()
        {
            return _repository.GetAll();
        }

        public bool Insert(Product product)
        {
            return _repository.Insert(product);
        }

        public bool Update(ProductDTO product)
        {
            Product edit = new Product()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };

            return _repository.Update(edit);
        }

        public bool UpdateStock(List<UpdateStock> product)
        {
            try
            {
                foreach (var item in product)
                {
                    _logger.LogInformation($"ProductServices => UpdateStock => Busca por id {item.ProductId}");
                    Product? Products = _db.Products.Find(item.ProductId);

                    if (Products != null)
                    {
                        _logger.LogInformation($"ProductServices => UpdateStock => Edita Stock");
                        Products.Stock = Products.Stock - item.Stock;

                        _logger.LogInformation($"ProductServices => UpdateStock => Guarda cambios");
                        _db.SaveChanges();
                    }
                    else
                    {
                        _logger.LogError($"ProductServices => UpdateStock => No encontro el campo");
                    }
                }

                return true;
            }
            catch (Exception)
            {
                _logger.LogError($"ProductServices => UpdateStock => Ocurrio un error");
                throw;
            }
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}