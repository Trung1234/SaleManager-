using SaleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleApi.Repositories
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly SaleManagerContext _context;

        public DataRepository(SaleManagerContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> SaveAsync(T entity)
        {
            await _context.SaveChangesAsync();
            return entity;
        }
        public T SaveChanges(T entity)
        {
           _context.SaveChanges();
            return entity;
        }
    }
}
