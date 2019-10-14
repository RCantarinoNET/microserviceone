using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProdutoMS.DBContexts;
using ProdutoMS.Repositories.Base;

namespace ProdutoMS.Repositories.Base
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly ProductContext  _context;
 
        #endregion

        public EfRepository(ProductContext context)
        {
            this._context = context;
        }


        public ValueTask<T> GetById(int id) => _context.Set<T>().FindAsync(id);

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate) =>
            _context.Set<T>().FirstOrDefaultAsync(predicate);
        
        public async Task<T> Add(T entidade)
        {
           await _context.Set<T>().AddAsync(entidade);
           return entidade;

        }

        public async Task<T> Update(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entidade;
        }

        public Task Remove(T entidade)
        {
            _context.Set<T>().Remove(entidade);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async  Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();

        }

        public Task<int> CountAll() => _context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate) 
            => _context.Set<T>().CountAsync(predicate);
    }
}