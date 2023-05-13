using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LinhDGT_Electronic.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Email là trường bắt buộc!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Nhớ mật khẩu?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Email là trường bắt buộc!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Tên tài khoản là trường bắt buộc!")]
        [Display(Name = "UserName")]
        //[EmailAddress(ErrorMessage = "Email không đúng định dạng!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu là trường bắt buộc!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Nhớ mật khẩu?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email là trường bắt buộc!")]
        [EmailAddress(ErrorMessage ="Email không đúng định dạng!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Tên tài khoản là trường bắt buộc!")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu là trường bắt buộc!")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải gồm ít nhất 6 ký tự!", MinimumLength = 6)]
        [DataType(DataType.Password,ErrorMessage ="Mật khẩu không đủ mạnh!")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp!")]
        public string ConfirmPassword { get; set; }
    }
    public class CreateAccountViewModel
    {
        [Required(ErrorMessage = "Email là trường bắt buộc!")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tên tài khoản là trường bắt buộc!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Họ tên là trường bắt buộc!")]
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
        public string Role { get; set; }

        [Required(ErrorMessage = "Mật khẩu là trường bắt buộc!")]
        [StringLength(100, ErrorMessage = "{0} phải gồm ít nhất {2} ký tự!", MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessage = "Mật khẩu không đủ mạnh!")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp!")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} phải gồm ít nhất {2} ký tự!", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp!")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage ="Email không được để rỗng!")]
        [EmailAddress(ErrorMessage ="Email không đúng định dạng!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
