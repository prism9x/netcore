using BookShop.DataAccess.DataAccess;
using BookShop.Domain.Abstract;

namespace BookShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _DbContext;


        private AppUserRepository? _appUserRepository;
        private BookCatalogRepository? _bookCatalogRepository;
        private BookRepository? _bookRepository;
        private CartDetailRepository? _cartDetailRepository;
        private CartRepository? _cartRepository;
        private CatalogRepository? _catalogRepository;
        private GerneRepository? _gerneRepository;
        private PaymentRepository? _paymentRepository;


        public UnitOfWork(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IAppUserRepository appUserRepository => _appUserRepository ??= new AppUserRepository(_DbContext);
        public IBookCatalogRepository bookCatalogRepository => _bookCatalogRepository ??= new BookCatalogRepository(_DbContext);
        public IBookRepository bookRepository => _bookRepository ??= new BookRepository(_DbContext);
        public ICartDetailRepository cartDetailRepository => _cartDetailRepository ??= new CartDetailRepository(_DbContext);
        public ICartRepository cartRepository => _cartRepository ??= new CartRepository(_DbContext);
        public ICatalogRepository catalogRepository => _catalogRepository ??= new CatalogRepository(_DbContext);
        public IGerneRepository gerneRepository => _gerneRepository ??= new GerneRepository(_DbContext);
        public IPaymentRepository paymentRepository => _paymentRepository ??= new PaymentRepository(_DbContext);

        public void Dispose()
        {
            if (_DbContext != null) _DbContext.Dispose();
        }

        public async Task SaveChangeAsync()
        {
            await _DbContext.SaveChangesAsync();
        }
    }
}