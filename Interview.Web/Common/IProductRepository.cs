using Interview.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Web.Common
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<bool> AddProduct(Product product);
    }
}
