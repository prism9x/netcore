using BookShop.Application.Services;
using BookShop.Domain.Entities;
using BookShop.UI.Areas.Admin.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthenticationController(IUserService userService, SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            var mdLogin = new LoginModel();
            return View(mdLogin);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

                ViewBag.Error = string.Join("<br/>", error);

                return View();
            }

            var result = await _userService.CheckLogin(loginModel.Username, loginModel.Password, loginModel.HasRememberMe);


            if (result.Status)
            {
                return RedirectToAction("Index", "Home");
            }

            TempData["errors"] = result.Message;
            return View(loginModel);

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

    }
}
