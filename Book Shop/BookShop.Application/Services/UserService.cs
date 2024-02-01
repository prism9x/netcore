using BookShop.Application.DTOs;
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


        /// <summary>
        /// Hàm kiểm tra đăng nhập
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="hasRemember"></param>
        /// <returns>Trả về một obj có kiểu <see cref="ResponseModel"/></returns>
        public async Task<ResponseModel> CheckLogin(string username, string password, bool hasRemember)
        {
            var user = await _userManager.FindByNameAsync(username);

            // Check user
            if (user is null)
            {
                return new ResponseModel
                {
                    Status = false,
                    Message = "Tài khoản không tồn trại",
                };
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: hasRemember, lockoutOnFailure: true);

            // Check locked out
            if (result.IsLockedOut)
            {
                var remaningLockout = user.LockoutEnd.Value - DateTimeOffset.UtcNow;
                return new ResponseModel
                {
                    Status = false,
                    Message = $"Tài khoản đã bị khóa. Thử lại sau {Math.Round(remaningLockout.TotalMinutes)} minutes",
                };
            }

            // Successful
            if (!result.Succeeded)
            {
                return new ResponseModel
                {
                    Status = false,
                    Message = "Tài khoản hoặc mật khẩu không đúng !"
                };
            }

            if (user.AccessFailedCount > 0)
            {
                await _userManager.ResetAccessFailedCountAsync(user);

            }

            return new ResponseModel
            {
                Status = true
            };

        }
    }
}
