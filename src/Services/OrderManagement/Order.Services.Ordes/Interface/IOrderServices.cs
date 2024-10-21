using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Products.Interface
{
    public interface IOrderServices
    {
        Domain.Order? GetById(int id);
        List<Domain.Order>? GetAll();
        bool Insert(CreateOrder createOrder);
        bool Update(Domain.Order product);
        bool Delete(int id);
    }
}
