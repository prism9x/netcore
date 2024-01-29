
using BookShop.Application.DTOs;

namespace BookShop.Application.Services
{
    public interface IUserService
    {
        Task<ResponseModel> CheckLogin(string username, string password, bool hasRemember);
    }
}