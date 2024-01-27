using BookShop.Application.Services;
using BookShop.UI.Areas.Admin.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthencationController : Controller
    {
        private readonly IUserService _userService;

        public AuthencationController(IUserService userService)
        {
            _userService = userService;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                bool result = await _userService.CheckLogin(loginModel.Username, loginModel.Password);
                if (!result)
                {
                    ViewBag.Error = "Username or password is invalid";
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                var error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                ViewBag.Error = string.Join("<br/>", error);
            }
            return View();
        }
    }
}



