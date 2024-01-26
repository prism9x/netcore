using BookShop.DataAccess.DataAccess;
using BookShop.Domain.Abstract;
using BookShop.Domain.Entities;

namespace BookShop.DataAccess.Repository
{
    public class CatalogRepository : GenericRepository<Catalog>, ICatalogRepository
    {
        public CatalogRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
