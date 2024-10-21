using Order.Domain;
using Order.Persistence.Database;
using Order.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Order.Test
{
    public class OrderServicesTests
    {
        private readonly DbContextOptions<OrderDbContext> _options;
        private readonly Mock<ILogger<Repository<Order.Domain.Order>>> _loggerMock;

        public OrderServicesTests()
        {
            _options = new DbContextOptionsBuilder<OrderDbContext>()
                        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                        .Options;

            _loggerMock = new Mock<ILogger<Repository<Order.Domain.Order>>>();


        }

        [Fact]
        public void GetById_Exists()
        {
            var context = new OrderDbContext(_options);

            context.Orders.Add(new Order.Domain.Order { OrderId = 1, CustomerId = 1, Status = "Status 1", TotalAmount = 100, OrderDate = DateTime.Now });
            context.Orders.Add(new Order.Domain.Order { OrderId = 2, CustomerId = 2, Status = "Status 2", TotalAmount = 200, OrderDate = DateTime.Now });

            context.SaveChanges();

            var repository = new Repository<Order.Domain.Order>(context, _loggerMock.Object);
            var product = repository.GetById(1);

            Assert.NotNull(product);
            Assert.Equal(1, product.OrderId);
        }


        [Fact]
        public void GetById_NotExist()
        {
            var context = new OrderDbContext(_options);

            var repository = new Repository<Order.Domain.Order>(context, _loggerMock.Object);

            var product = repository.GetById(3);

            Assert.Null(product);
        }

        [Fact]
        public void GetAll()
        {
            var context = new OrderDbContext(_options);

            context.Orders.Add(new Order.Domain.Order { OrderId = 1, CustomerId = 1, Status = "Status 1", TotalAmount = 100, OrderDate = DateTime.Now });
            context.Orders.Add(new Order.Domain.Order { OrderId = 2, CustomerId = 2, Status = "Status 2", TotalAmount = 200, OrderDate = DateTime.Now });
            context.SaveChanges();

            var repository = new Repository<Order.Domain.Order>(context, _loggerMock.Object);
            var products = repository.GetAll();

            Assert.Equal(2, products?.Count);
        }

        [Fact]
        public void Insert()
        {
            var context = new OrderDbContext(_options);

            var newOrder = new Order.Domain.Order { OrderId = 1, CustomerId = 1, Status = "Status 1", TotalAmount = 100, OrderDate = DateTime.Now };

            var repository = new Repository<Order.Domain.Order>(context, _loggerMock.Object);
            var result = repository.Insert(newOrder);

            Assert.True(result);
            Assert.Equal(1, repository.GetAll()?.Count);
        }

        [Fact]
        public void Update()
        {
            var context = new OrderDbContext(_options);

            context.Orders.Add(new Order.Domain.Order { OrderId = 1, CustomerId = 1, Status = "Status 1", TotalAmount = 100, OrderDate = DateTime.Now });
            context.SaveChanges();

            var productToUpdate = new Order.Domain.Order { OrderId = 1, CustomerId = 2, Status = "StatusP 2", TotalAmount = 200, OrderDate = DateTime.Now };

            var contextUpdate = new OrderDbContext(_options);
            var repository = new Repository<Order.Domain.Order>(contextUpdate, _loggerMock.Object);
            var result = repository.Update(productToUpdate);

            Assert.True(result);

            var updatedProduct = repository.GetById(1);
            Assert.Equal("StatusP 2", updatedProduct?.Status);
        }

        [Fact]
        public void Delete()
        {
            var context = new OrderDbContext(_options);

            context.Orders.Add(new Order.Domain.Order { OrderId = 1, CustomerId = 1, Status = "Status 1", TotalAmount = 100, OrderDate = DateTime.Now });
            context.SaveChanges();

            var repository = new Repository<Order.Domain.Order>(context, _loggerMock.Object);
            var result = repository.Delete(1);

            Assert.True(result);

            var product = repository.GetById(1);
            Assert.Null(product);
        }

        [Fact]
        public void Delete_NotExist()
        {
            var context = new OrderDbContext(_options);

            var repository = new Repository<Order.Domain.Order>(context, _loggerMock.Object);
            var result = repository.Delete(1);

            Assert.False(result);
        }
    }
}