using Microsoft.EntityFrameworkCore;
using PayrollManagement.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayrollManagement.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public virtual async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public virtual void Remove(T entity) => _dbSet.Remove(entity);

        public virtual void Update(T entity) => _dbSet.Update(entity);
    }
}
