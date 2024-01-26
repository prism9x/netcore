namespace BookShop.Domain.Abstract
{
    public interface IUnitOfWork
    {
        IAppUserRepository appUserRepository { get; }
        IBookCatalogRepository bookCatalogRepository { get; }
        IBookRepository bookRepository { get; }
        ICartDetailRepository cartDetailRepository { get; }
        ICartRepository cartRepository { get; }
        ICatalogRepository catalogRepository { get; }
        IGerneRepository gerneRepository { get; }
        IPaymentRepository paymentRepository { get; }

        Task SaveChangeAsync();
    }
}