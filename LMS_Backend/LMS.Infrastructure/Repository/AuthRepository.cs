using LMS_Backend.LMS.Application.DTOs.Authentication;
using LMS_Backend.LMS.Application.Interfaces.Authentication;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Common.Exceptions;
using LMS_Backend.LMS.Infrastructure.Helpers;
using LMS_Backend.LMS.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using LMS_Backend.LMS.Infrastructure.Context;
using LMS_Backend.LMS.Application.DTOs.NewFolder;

namespace LMS_Backend.LMS.Infrastructure.Repository
{
    public class AuthRepository : GenericRepository<User>, IAuthRepository
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly JwtTokenHelper _jwtTokenHelper;

        public AuthRepository(ApplicationDBContext context, IAuthService authService, IEmailService emailService, JwtTokenHelper jwtTokenHelper) : base(context)
        {
            _authService = authService;
            _emailService = emailService;
            _jwtTokenHelper = jwtTokenHelper;
        }

        public async Task<object> LoginAsync(LoginDTO userLogin)
        {
            var user = await _authService.GetUserByEmailAsync(userLogin.Email);

            if (user == null)
                throw new DataNotFoundException<string>("Invalid email or password.");

            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userLogin.Password);

            if (result != PasswordVerificationResult.Success)
                throw new Exception("Invalid email or password.");

            var token = _jwtTokenHelper.GenerateToken(userLogin, user.RoleId, user.UserId);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("JWT Token: " + token);

            var userDto = new UserDTO
            {
                Id = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.RoleName,
                ProfileImageUrl = user.ProfileImageUrl
            };

            return new
            {
                token,
                user = userDto
            };
        }

        public async Task<bool> ResetPassword(ResetPwdDTO resetPwd)
        {
            var user = await _authService.GetUserByEmailAsync(resetPwd.Email);
            if (user == null)
                throw new DataNotFoundException<string>("User not found.");

            if (!OtpStore.UserOtps.TryGetValue(resetPwd.Email, out var otpInfo))
                throw new Exception("OTP not found or expired.");

            if (DateTime.UtcNow > otpInfo.Expiration)
                throw new Exception("OTP has expired.");

            if (otpInfo.Otp != resetPwd.Otp)
                throw new Exception("OTP mismatched.");

            return await _authService.UpdatePasswordDB(resetPwd.NewPassword, user);
        }

        public async Task<int> SendOtpToEmail(ForgotPwdDTO dto)
        {
            return await _authService.GenerateAndSendOtpAsync(dto.Email);
        }

        public async Task<string> RegisterAsync(RegisterDTO register)
        {
            var existingUser = await _authService.CheckUserExistsAsync(register.Email);

            if (existingUser)
            {
                throw new AlreadyExistsException<string>("USER ALREADY EXISTS.");
            }

            var passwordHasher = new PasswordHasher<RegisterDTO>();
            var hashedPassword = passwordHasher.HashPassword(register, register.Password);

            var newUser = new User
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                MobileNo = register.MobileNo,
                PasswordHash = hashedPassword,
                RoleId = 3,
                IsActive = true,
                IsDeleted = false,
                ProfileImageUrl = register.ProfileImageUrl,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = 0
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            await _emailService.SendStudentRegistrationEmailAsync(register.Email, (register.FirstName + " " + register.LastName));

            return "User is registered successfully.";
        }
    }
}