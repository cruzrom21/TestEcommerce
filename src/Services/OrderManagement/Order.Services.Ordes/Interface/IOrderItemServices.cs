using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Products.Interface
{
    public interface IOrderItemServices
    {
        OrderItem? GetById(int id);
        List<OrderItem>? GetAll();
        bool Insert(OrderItem product);
        bool Update(OrderItem product);
        bool Delete(int id);
    }
}
