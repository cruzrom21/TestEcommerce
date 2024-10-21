using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models
{
    public class UpdateStock
    {
        public int ProductId { get; set; }

        public int Stock { get; set; }
    }
}
