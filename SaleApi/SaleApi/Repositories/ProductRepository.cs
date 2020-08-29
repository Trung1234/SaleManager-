using SaleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SaleManagerContext _context;

        public ProductRepository(SaleManagerContext context)
        {
            _context = context;
        }
        public void Add(Product entity)
        {
            _context.Set<Product>().Add(entity);
        }
        public void Update(Product entity)
        {
            _context.Set<Product>().Update(entity);
        }
        public void Delete(Product entity)
        {
            _context.Set<Product>().Remove(entity);
        } 

        public async Task<Product> SaveAsync(Product entity)
        {
            await _context.SaveChangesAsync();
            return entity;
        }

        
    }
}
