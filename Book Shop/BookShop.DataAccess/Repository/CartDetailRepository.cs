using BookShop.DataAccess.DataAccess;
using BookShop.Domain.Abstract;
using BookShop.Domain.Entities;

namespace BookShop.DataAccess.Repository
{
    public class CartDetailRepository : GenericRepository<CartDetail>, ICartDetailRepository
    {
        public CartDetailRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
