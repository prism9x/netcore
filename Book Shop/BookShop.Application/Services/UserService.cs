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
            Console.WriteLine($"user name: {user.UserName}");
            Console.WriteLine($"string password: {password}");
            var rs = _signInManager.CheckPasswordSignInAsync(user, password, false);
            Console.WriteLine($"rs: {rs.Result}");

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);



            return result.Succeeded;

        }
    }
}
