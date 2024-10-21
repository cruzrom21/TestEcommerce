
using Order.Domain;
using Order.Persistence.Database;
using Order.Persistence.Repository;
using Order.Services.Products.Interface;
using Microsoft.Extensions.Logging;
using Order.Services.Proxies.Interface;
using static Order.Services.Proxies.Catalog.CatalogProxy;

namespace Order.Services.Orders
{
    public class OrderServices : IOrderServices
    {
        private OrderDbContext _db;
        private IRepository<Domain.Order> _repository;
        private IRepository<OrderItem> _repositoryItem;
        private ILogger<OrderServices> _logger;
        private ICatalogProxy _catalogProxy;


        public OrderServices(OrderDbContext dbContext, IRepository<Domain.Order> repository, IRepository<OrderItem> repositoryItem, ILogger<OrderServices> logger, ICatalogProxy catalogProxy)
        {
            _db = dbContext;
            _repository = repository;
            _repositoryItem = repositoryItem;
            _logger = logger;
            _catalogProxy = catalogProxy;
        }

        public Domain.Order? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Domain.Order>? GetAll()
        {
            return _repository.GetAll();
        }

        public bool Insert(CreateOrder createOrder)
        {

            Domain.Order order = new Domain.Order()
            {
                CustomerId = createOrder.Order.CustomerId,
                TotalAmount = createOrder.Order.TotalAmount,
                Status = createOrder.Order.Status,
                OrderDate = createOrder.Order.OrderDate
            };

            Domain.Order insert = _repository.InsertResult(order);


            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var item in createOrder.Items)
            {
                orderItems.Add(new OrderItem
                {
                    OrderId = insert.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
            }


            bool insertItem = _repositoryItem.InsertRange(orderItems);

            _catalogProxy.UpdateStock(orderItems);

            return insert.OrderId > 0 && insertItem == true ? true : false;
        }

        public bool Update(Domain.Order product)
        {
            return _repository.Update(product);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}