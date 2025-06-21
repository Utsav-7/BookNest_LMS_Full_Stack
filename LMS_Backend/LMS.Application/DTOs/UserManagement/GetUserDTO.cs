using LMS_Backend.LMS.Application.DTOs.NewFolder;

namespace LMS_Backend.LMS.Application.DTOs.UserManagement
{
    public class GetUserDTO : UserDTO
    {
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
    }
}