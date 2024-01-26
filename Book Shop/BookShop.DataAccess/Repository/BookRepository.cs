using BookShop.DataAccess.DataAccess;
using BookShop.Domain.Abstract;
using BookShop.Domain.Entities;

namespace BookShop.DataAccess.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}