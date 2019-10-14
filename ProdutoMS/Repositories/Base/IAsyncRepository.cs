using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProdutoMS.Repositories.Base
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        ValueTask<T> GetById(int id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
       
        Task<T> Add(T entidade);
        Task<T> Update(T entidade);
        Task Remove(T entidade);
        
        
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}