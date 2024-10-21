using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Services.Products.Interface
{
    public interface IProductServices
    {
        Product? GetById(int id);
        List<Product>? GetAll();
        bool Insert(Product product);
        bool Update(ProductDTO product);
        bool UpdateStock(List<UpdateStock> product);
        bool Delete(int id);
    }
}
