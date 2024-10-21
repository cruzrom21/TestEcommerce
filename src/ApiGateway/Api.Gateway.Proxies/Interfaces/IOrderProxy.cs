using Api.Gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies
{
    public  interface IOrderProxy
    {
        Task<List<Order>?> GetAll();
        Task<Order?> GetById(int id);
        Task Insert(CreateOrder product);
        Task Update(Order product);
        Task Delete(int id);

        Task<List<OrderItem>?> GetAllItem();
        Task<OrderItem?> GetByIdItem(int id);
        Task InsertItem(OrderItem product);
        Task UpdateItem(OrderItem product);
        Task DeleteItem(int id);
    }
}
