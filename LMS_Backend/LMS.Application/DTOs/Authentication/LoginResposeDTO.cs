using LMS_Backend.LMS.Application.DTOs.NewFolder;

namespace LMS_Backend.LMS.Application.DTOs.Authentication
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}