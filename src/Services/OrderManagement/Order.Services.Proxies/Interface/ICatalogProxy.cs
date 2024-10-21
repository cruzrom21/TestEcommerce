using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Proxies.Interface
{
    public  interface ICatalogProxy
    {
        Task UpdateStock(List<OrderItem> listItems);
    }
}
