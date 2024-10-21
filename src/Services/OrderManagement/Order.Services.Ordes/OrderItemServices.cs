
using Order.Domain;
using Order.Persistence.Database;
using Order.Persistence.Repository;
using Order.Services.Products.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace Order.Services.Orders
{
    public class OrderItemsServices : IOrderItemServices
    {
        private OrderDbContext _db;
        private IRepository<OrderItem> _repository;
        private ILogger<OrderItemsServices> _logger;

        public OrderItemsServices(OrderDbContext dbContext, IRepository<OrderItem> repository, ILogger<OrderItemsServices> logger)
        {
            _db = dbContext;
            _repository = repository;
            _logger = logger;
        }

        public OrderItem? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<OrderItem>? GetAll()
        {
            return _repository.GetAll();
        }

        public bool Insert(OrderItem product)
        {
            return _repository.Insert(product);
        }

        public bool Update(OrderItem product)
        {
            return _repository.Update(product);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}