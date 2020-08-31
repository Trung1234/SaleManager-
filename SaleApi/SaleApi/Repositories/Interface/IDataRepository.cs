using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleApi.Repositories
{
    public interface IDataRepository<T> where T : class
    {
        void Add(T entity);        
    }
}
