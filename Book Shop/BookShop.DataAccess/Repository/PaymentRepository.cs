using BookShop.DataAccess.DataAccess;
using BookShop.Domain.Abstract;
using BookShop.Domain.Entities;

namespace BookShop.DataAccess.Repository
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
