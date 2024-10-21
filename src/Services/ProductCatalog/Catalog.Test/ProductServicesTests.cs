using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Persistence.Repository;
using Catalog.Services.Products;
using Catalog.Services.Products.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Catalog.Test
{
    public class ProductServicesTests
    {
        private readonly DbContextOptions<ProductDbContext> _options;
        private readonly Mock<ILogger<Repository<Product>>> _loggerMock;

        public ProductServicesTests()
        {
            _options = new DbContextOptionsBuilder<ProductDbContext>()
                        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                        .Options;

            _loggerMock = new Mock<ILogger<Repository<Product>>>();


        }

        [Fact]
        public void GetById_Exists()
        {
            var context = new ProductDbContext(_options);

            context.Products.Add(new Product { ProductId = 1, Name = "Prueba1", Description = "Prueba 1", Price = 100, Stock = 100 });
            context.Products.Add(new Product { ProductId = 2, Name = "Prueba2", Description = "Prueba 2", Price = 200, Stock = 200 });
            context.SaveChanges();

            var repository = new Repository<Product>(context, _loggerMock.Object);
            var product = repository.GetById(1);

            Assert.NotNull(product);
            Assert.Equal(1, product.ProductId);
            Assert.Equal("Prueba1", product.Name);
        }


        [Fact]
        public void GetById_NotExist()
        {
            var context = new ProductDbContext(_options);

            var repository = new Repository<Product>(context, _loggerMock.Object);

            var product = repository.GetById(3);

            Assert.Null(product);
        }

        [Fact]
        public void GetAll()
        {
            var context = new ProductDbContext(_options);

            context.Products.Add(new Product { ProductId = 1, Name = "Prueba1", Description = "Prueba 1", Price = 100, Stock = 100 });
            context.Products.Add(new Product { ProductId = 2, Name = "Prueba2", Description = "Prueba 2", Price = 200, Stock = 200 });
            context.SaveChanges();

            var repository = new Repository<Product>(context, _loggerMock.Object);
            var products = repository.GetAll();

            Assert.Equal(2, products?.Count);
        }

        [Fact]
        public void Insert()
        {
            var context = new ProductDbContext(_options);

            var newProduct = new Product { ProductId = 3, Name = "Prueba3", Description = "Prueba 3", Price = 300, Stock = 300 };

            var repository = new Repository<Product>(context, _loggerMock.Object);
            var result = repository.Insert(newProduct);

            Assert.True(result);
            Assert.Equal(1, repository.GetAll()?.Count);
        }

        [Fact]
        public void Update()
        {
            var context = new ProductDbContext(_options);

            context.Products.Add(new Product { ProductId = 1, Name = "Prueba1", Description = "Prueba 1", Price = 100, Stock = 100 });
            context.SaveChanges();

            var productToUpdate = new Product { ProductId = 1, Name = "PruebaUpdate3", Description = "PruebaUpdate 3", Price = 300, Stock = 300 };

            var contextUpdate = new ProductDbContext(_options);
            var repository = new Repository<Product>(contextUpdate, _loggerMock.Object);
            var result = repository.Update(productToUpdate);

            Assert.True(result);

            var updatedProduct = repository.GetById(1);
            Assert.Equal("PruebaUpdate3", updatedProduct?.Name);
        }

        [Fact]
        public void Delete()
        {
            var context = new ProductDbContext(_options);

            context.Products.Add(new Product { ProductId = 1, Name = "Prueba1", Description = "Prueba 1", Price = 100, Stock = 100 });
            context.SaveChanges();

            var repository = new Repository<Product>(context, _loggerMock.Object);
            var result = repository.Delete(1);

            Assert.True(result);

            var product = repository.GetById(1);
            Assert.Null(product);
        }

        [Fact]
        public void Delete_NotExist()
        {
            var context = new ProductDbContext(_options);

            var repository = new Repository<Product>(context, _loggerMock.Object);
            var result = repository.Delete(1);

            Assert.False(result);
        }

        [Fact]
        public void UpdateStock()
        {
            var context = new ProductDbContext(_options);

            context.Products.Add(new Product { ProductId = 1, Name = "Prueba1", Description = "Prueba 1", Price = 100, Stock = 100 });
            context.Products.Add(new Product { ProductId = 2, Name = "Prueba2", Description = "Prueba 2", Price = 200, Stock = 200 });

            context.SaveChanges();

            var repositoryMock = new Mock<IRepository<Product>>();
            var loggerMock = new Mock<ILogger<ProductServices>>();

            var _productService = new ProductServices(context, repositoryMock.Object, loggerMock.Object);

            List<UpdateStock> updateStock = new List<UpdateStock>()
            {
                new UpdateStock
                {
                    ProductId = 1,
                    Stock = 10
                },
                new UpdateStock
                {
                    ProductId = 1,
                    Stock = 10
                }
            };

            var result = _productService.UpdateStock(updateStock);

            Assert.True(result);

            var updatedProduct = context.Products.Find(1);
            Assert.Equal(80, updatedProduct?.Stock);
        }



    }
}