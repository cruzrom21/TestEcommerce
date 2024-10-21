using Api.Gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies
{
    public  interface ICatalogProxy
    {
        Task<List<Product>?> GetAll();
        Task<Product?> GetById(int id);
        Task Insert(Product product);
        Task Update(ProductDTO product);
        Task UpdateStock(List<UpdateStock> productUpdate);
        Task Delete(int id);
    }
}
