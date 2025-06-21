using LMS_Backend.LMS.Application.DTOs.NewFolder;
using LMS_Backend.LMS.Application.DTOs.User;
using LMS_Backend.LMS.Application.DTOs.UserManagement;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.UserManagement
{
    public interface IUserService
    {
        public Task<GetUserDTO?> GetUserByIdAsync(int id);
        public Task<IEnumerable<GetUserDTO>> GetAllUsersAsync();
        public Task<IEnumerable<GetUserDTO>> GetUsersByRoleAsync(string role);
        public Task<int> AddUserAsync(UserDataDTO userDto, int createdBy);
        public Task<bool> UpdateUserAsync(UserDataDTO userDto, int updatedBy);
        public Task<bool> PatchUserAsync(int id, JsonPatchDocument<UserDataDTO> patchDoc, int updatedBy);
        public Task<bool> DeleteUserAsync(int id, int deletedBy);
    }
}