using System.ComponentModel.DataAnnotations;

namespace BookShop.UI.Areas.Admin.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(3, ErrorMessage = "Mật khẩu phải nhiều hơn 3 kí tự")]
        public string Password { get; set; }

        public bool HasRememberMe { get; set; }
    }
}
