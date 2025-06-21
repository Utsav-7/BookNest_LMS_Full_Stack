using LMS_Backend.LMS.Application.Interfaces.Authentication;
using LMS_Backend.LMS.Application.Interfaces;
using LMS_Backend.LMS.Common.Exceptions;
using LMS_Backend.LMS.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.LMS.Infrastructure.Repository
{
    public class AuthService : GenericRepository<User>, IAuthService
    {
        private readonly IEmailService _emailService;

        public AuthService(IEmailService emailService, ApplicationDBContext context) : base(context)
        {
            _emailService = emailService;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(e => e.Email == email && e.IsActive == true);

                if (user == null)
                    throw new DataNotFoundException<string>("USER NOT FOUND.");

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CheckUserExistsAsync(string email)
        {
            try
            {
                var existinguser = await _context.Users.FirstOrDefaultAsync(e => e.Email == email);

                return existinguser != null ? true : false;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdatePasswordDB(string newPassword, User user)
        {
            try
            {
                var passwordHasher = new PasswordHasher<User>();
                user.PasswordHash = passwordHasher.HashPassword(user, newPassword);

                _context.Users.Update(user);

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> GenerateAndSendOtpAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);

            int otp = new Random().Next(100000, 999999);

            OtpStore.UserOtps[email] = (otp, DateTime.UtcNow.AddMinutes(10));

            Console.WriteLine("Reset Password OTP: " + otp);

            string subject = "Your Secure OTP for Password Reset - Expires in 10 Minutes";

            string message = $@"
                <div style='font-family:Segoe UI, sans-serif; padding:20px; color:#333;'>
                    <h2 style='color:#0A7EFF;'>BookNest Password Reset Request</h2>
                    <p>Hello,</p>
                    <p>You requested to reset your password. Please use the OTP below to proceed:</p>
                    <div style='font-size:24px; font-weight:bold; margin:20px 0; color:#0A7EFF;'>{otp}</div>
                    <p>This OTP is valid for <strong>10 minutes</strong>.</p>
                    <p>If you didn’t request this, please ignore this email or contact support.</p>
                    <hr/>
                    <p style='font-size:12px; color:gray;'>Thank you,<br/>BookNest Team</p>
                </div>";

            await _emailService.SendEmailAsync(email, subject, message);

            return otp;
        }
    }
}