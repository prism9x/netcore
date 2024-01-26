using BookShop.DataAccess.DataAccess;
using BookShop.Domain.Abstract;
using BookShop.Domain.Entities;

namespace BookShop.DataAccess.Repository
{
    public class GerneRepository : GenericRepository<Genre>, IGerneRepository
    {
        public GerneRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
