using BookShop.DataAccess.DataAccess;
using BookShop.Domain.Abstract;
using BookShop.Domain.Entities;

namespace BookShop.DataAccess.Repository
{
    public class BookCatalogRepository : GenericRepository<BookCatalog>, IBookCatalogRepository
    {
        public BookCatalogRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
