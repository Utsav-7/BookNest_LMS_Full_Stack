using LMS_Backend.LMS.Application.DTOs.NewFolder;
using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Application.DTOs.User
{
    public class UserDataDTO : UserDTO
    {
        [Required(ErrorMessage = "Mobile number is required.")]
        [Phone(ErrorMessage = "Invalid mobile number format.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number must be 10 digits (Exclude country code).")]
        public string MobileNo { get; set; }

        public bool IsActive { get; set; }
        public string? PasswordHash { get; set; }
    }
}