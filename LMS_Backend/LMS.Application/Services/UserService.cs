using LMS_Backend.LMS.Application.DTOs.User;
using LMS_Backend.LMS.Application.DTOs.UserManagement;
using LMS_Backend.LMS.Application.Interfaces.UserManagement;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> AddUserAsync(UserDataDTO userDto, int createdBy)
        {
            return await _userRepository.AddUserQuery(userDto, createdBy);
        }

        public async Task<bool> DeleteUserAsync(int id, int deletedBy)
        {
            return await _userRepository.DeleteUserQuery(id, deletedBy);
        }

        public async Task<IEnumerable<GetUserDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersQuery();
        }

        public async Task<GetUserDTO?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdQuery(id);
        }

        public async Task<IEnumerable<GetUserDTO>> GetUsersByRoleAsync(string role)
        {
            return await _userRepository.GetUsersByRoleQuery(role);
        }

        public async Task<bool> PatchUserAsync(int id, JsonPatchDocument<UserDataDTO> patchDoc, int updatedBy)
        {
            return await _userRepository.PatchUserQuery(id, patchDoc, updatedBy);
        }

        public async Task<bool> UpdateUserAsync(UserDataDTO userDto, int updatedBy)
        {
            return await _userRepository.UpdateUserQuery(userDto, updatedBy);
        }
    }
}