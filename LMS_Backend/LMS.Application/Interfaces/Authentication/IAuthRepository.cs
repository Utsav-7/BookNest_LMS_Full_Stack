using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.Authentication
{
    public interface IAuthService
    {
        public Task<User> GetUserByEmailAsync(string email);
        public Task<bool> CheckUserExistsAsync(string email);
        public Task<bool> UpdatePasswordDB(string newPassword, User user);
        public Task<int> GenerateAndSendOtpAsync(string email);
    }
}