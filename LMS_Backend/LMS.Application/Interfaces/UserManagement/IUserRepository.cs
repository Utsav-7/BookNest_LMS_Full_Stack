using LMS_Backend.LMS.Application.DTOs.User;
using LMS_Backend.LMS.Application.DTOs.UserManagement;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.UserManagement
{
    public interface IUserRepository
    {
        public Task<GetUserDTO?> GetUserByIdQuery(int id);
        public Task<IEnumerable<GetUserDTO>> GetAllUsersQuery();
        public Task<IEnumerable<GetUserDTO>> GetUsersByRoleQuery(string role);
        public Task<int> AddUserQuery(UserDataDTO userDto, int createdBy);
        public Task<bool> UpdateUserQuery(UserDataDTO userDto, int updatedBy);
        public Task<bool> PatchUserQuery(int id, JsonPatchDocument<UserDataDTO> patchDoc, int updatedBy);
        public Task<bool> DeleteUserQuery(int id, int deletedBy);
    }
}