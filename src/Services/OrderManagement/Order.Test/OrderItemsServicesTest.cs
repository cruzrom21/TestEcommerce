using Order.Domain;
using Order.Persistence.Database;
using Order.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Order.Test
{
    public class OrderItemsServicesTest
    {
        private readonly DbContextOptions<OrderDbContext> _options;
        private readonly Mock<ILogger<Repository<OrderItem>>> _loggerMock;

        public OrderItemsServicesTest()
        {
            _options = new DbContextOptionsBuilder<OrderDbContext>()
                        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                        .Options;

            _loggerMock = new Mock<ILogger<Repository<OrderItem>>>();


        }

        [Fact]
        public void GetById_Exists()
        {
            var context = new OrderDbContext(_options);

            context.Orders.Add(new Domain.Order { OrderId = 1, CustomerId = 1, Status = "Status 1", TotalAmount = 100, OrderDate = DateTime.Now });
            context.Orders.Add(new Domain.Order { OrderId = 2, CustomerId = 2, Status = "Status 2", TotalAmount = 200, OrderDate = DateTime.Now });

            context.OrderItems.Add(new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 100, });
            context.OrderItems.Add(new OrderItem { OrderItemId = 2, OrderId = 1, ProductId = 2, Quantity = 2, UnitPrice = 100, });
            context.OrderItems.Add(new OrderItem { OrderItemId = 3, OrderId = 2, ProductId = 1, Quantity = 3, UnitPrice = 100, });
            context.OrderItems.Add(new OrderItem { OrderItemId = 4, OrderId = 2, ProductId = 2, Quantity = 3, UnitPrice = 100, });

            context.SaveChanges();

            var repository = new Repository<OrderItem>(context, _loggerMock.Object);
            var product = repository.GetById(1);

            Assert.NotNull(product);
            Assert.Equal(1, product.OrderId);
        }


        [Fact]
        public void GetById_NotExist()
        {
            var context = new OrderDbContext(_options);

            var repository = new Repository<OrderItem>(context, _loggerMock.Object);

            var product = repository.GetById(3);

            Assert.Null(product);
        }

        [Fact]
        public void GetAll()
        {
            var context = new OrderDbContext(_options);

            context.Orders.Add(new Domain.Order { OrderId = 1, CustomerId = 1, Status = "Status 1", TotalAmount = 100, OrderDate = DateTime.Now });
            context.Orders.Add(new Domain.Order { OrderId = 2, CustomerId = 2, Status = "Status 2", TotalAmount = 200, OrderDate = DateTime.Now });

            context.OrderItems.Add(new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 100 });
            context.OrderItems.Add(new OrderItem { OrderItemId = 2, OrderId = 1, ProductId = 2, Quantity = 2, UnitPrice = 200 });
            context.OrderItems.Add(new OrderItem { OrderItemId = 3, OrderId = 2, ProductId = 1, Quantity = 3, UnitPrice = 100 });
            context.OrderItems.Add(new OrderItem { OrderItemId = 4, OrderId = 2, ProductId = 2, Quantity = 3, UnitPrice = 200 });
            context.SaveChanges();

            var repository = new Repository<OrderItem>(context, _loggerMock.Object);
            var products = repository.GetAll();

            Assert.Equal(4, products?.Count);
        }

        [Fact]
        public void Insert()
        {
            var context = new OrderDbContext(_options);

            context.Orders.Add(new Domain.Order { OrderId = 1, CustomerId = 1, Status = "Status 1", TotalAmount = 100, OrderDate = DateTime.Now });
            context.SaveChanges();

            var newOrder = new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 100 };

            var repository = new Repository<OrderItem>(context, _loggerMock.Object);
            var result = repository.Insert(newOrder);

            Assert.True(result);
            Assert.Equal(1, repository.GetAll()?.Count);
        }

        [Fact]
        public void Update()
        {
            var context = new OrderDbContext(_options);

            context.Orders.Add(new Domain.Order { OrderId = 1, CustomerId = 1, Status = "Status 1", TotalAmount = 100, OrderDate = DateTime.Now });

            context.OrderItems.Add(new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 100 });
            context.OrderItems.Add(new OrderItem { OrderItemId = 2, OrderId = 1, ProductId = 2, Quantity = 2, UnitPrice = 200 });
            context.SaveChanges();

            var productToUpdate = new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 5, UnitPrice = 100 };

            var contextUpdate = new OrderDbContext(_options);
            var repository = new Repository<OrderItem>(contextUpdate, _loggerMock.Object);
            var result = repository.Update(productToUpdate);

            Assert.True(result);

            var updatedProduct = repository.GetById(1);
            Assert.Equal(5, updatedProduct?.Quantity);
        }

        [Fact]
        public void Delete()
        {
            var context = new OrderDbContext(_options);

            context.Orders.Add(new Domain.Order { OrderId = 1, CustomerId = 1, Status = "Status 1", TotalAmount = 100, OrderDate = DateTime.Now });

            context.OrderItems.Add(new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 100 });
            context.OrderItems.Add(new OrderItem { OrderItemId = 2, OrderId = 1, ProductId = 2, Quantity = 2, UnitPrice = 200 });
            context.SaveChanges();

            var repository = new Repository<OrderItem>(context, _loggerMock.Object);
            var result = repository.Delete(2);

            Assert.True(result);

            var product = repository.GetById(2);
            Assert.Null(product);
        }

        [Fact]
        public void Delete_NotExist()
        {
            var context = new OrderDbContext(_options);

            var repository = new Repository<OrderItem>(context, _loggerMock.Object);
            var result = repository.Delete(1);

            Assert.False(result);
        }
    }
}