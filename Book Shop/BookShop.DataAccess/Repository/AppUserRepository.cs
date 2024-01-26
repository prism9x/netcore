using BookShop.DataAccess.DataAccess;
using BookShop.Domain.Abstract;
using BookShop.Domain.Entities;

namespace BookShop.DataAccess.Repository
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
