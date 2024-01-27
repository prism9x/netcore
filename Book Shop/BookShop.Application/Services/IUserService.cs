
namespace BookShop.Application.Services
{
    public interface IUserService
    {
        Task<bool> CheckLogin(string username, string password);
    }
}