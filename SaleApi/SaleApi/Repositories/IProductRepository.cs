using SaleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleApi.Repositories
{
    public interface IProductRepository : IDataRepository<Product>
    {
        void Update(Product entity);
        void Delete(Product entity);
        Task<Product> SaveAsync(Product entity);       
    }
}
