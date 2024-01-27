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
        #region GetAll
        public async Task<IEnumerable<T?>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression is null)
            {
                return await _DbContext.Set<T>().ToListAsync().ConfigureAwait(false); ;
            }

            return await _DbContext.Set<T>().Where(expression).ToListAsync();
        }
        #endregion

        #region GetSingle
        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression = null)
        {
            return await _DbContext.Set<T>().SingleOrDefaultAsync(expression).ConfigureAwait(false); ;
        }
        #endregion

        #region Create
        public async Task CreateAsync(T entity)
        {
            await _DbContext.Set<T>().AddAsync(entity).ConfigureAwait(false);
        }
        #endregion

        #region Update
        public void Update(T entity)
        {
            _DbContext.Set<T>().Update(entity);
        }
        #endregion

        #region Delete
        public void Delete(T entity)
        {
            _DbContext.Set<T>().Remove(entity);
        }
        #endregion

        public async Task Commit()
        {
            await _DbContext.SaveChangesAsync();
        }
    }
}