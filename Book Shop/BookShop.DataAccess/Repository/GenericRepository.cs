using BookShop.DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.DataAccess.Repository
{
    public class GenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _DbContext;

        public GenericRepository(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<IEnumerable<T?>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression is null)
            {
                return await _DbContext.Set<T>().ToListAsync().ConfigureAwait(false); ;
            }

            return await _DbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression = null)
        {
            return await _DbContext.Set<T>().SingleOrDefaultAsync(expression).ConfigureAwait(false); ;
        }

        public async Task CreateAsync(T entity)
        {
            await _DbContext.Set<T>().AddAsync(entity).ConfigureAwait(false);
        }

        public void Update(T entity)
        {
            _DbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _DbContext.Set<T>().Remove(entity);
        }

        public async Task Commit()
        {
            await _DbContext.SaveChangesAsync();
        }
    }
}