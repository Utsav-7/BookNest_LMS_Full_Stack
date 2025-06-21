using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Application.DTOs.Authentication
{
    public class ForgotPwdDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;
    }
}