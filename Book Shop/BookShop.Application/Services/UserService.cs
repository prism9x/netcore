using BookShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Application.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<bool> CheckLogin(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user is null)
            {
                return false;
            }
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            return result.Succeeded;

        }
    }
}
