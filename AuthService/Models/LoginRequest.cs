using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Tài khoản không được để trống!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        public string PasswordHash { get; set; }
    }

}
