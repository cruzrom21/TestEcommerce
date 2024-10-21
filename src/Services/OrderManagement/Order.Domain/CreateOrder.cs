using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain
{
    public class CreateOrder
    {
        public COrder Order { get; set; }
        public List<COrderItem> Items { get; set; }
    }

    public class COrder
    {
        public int CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = null!;

        public DateTime OrderDate { get; set; }
    }

    public class COrderItem
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }

}
