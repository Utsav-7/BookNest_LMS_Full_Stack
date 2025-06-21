using AutoMapper;
using LMS_Backend.LMS.Application.DTOs.User;
using LMS_Backend.LMS.Application.DTOs.UserManagement;
using LMS_Backend.LMS.Application.Interfaces;
using LMS_Backend.LMS.Application.Interfaces.UserManagement;
using LMS_Backend.LMS.Common.Exceptions;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.LMS.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDBContext context, IMapper mapper, IEmailService emailService) : base(context)
        {
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<int> AddUserQuery(UserDataDTO userDto, int createdBy)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(s => s.Email == userDto.Email);

            if (existingUser != null)
                throw new AlreadyExistsException<string>("User already exists.");

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == userDto.Role);
            if (role == null)
                throw new DataNotFoundException<string>($"Role '{userDto.Role}' does not exist.");

            var passwordHasher = new PasswordHasher<UserDataDTO>();
            var hashedPassword = passwordHasher.HashPassword(userDto, userDto.PasswordHash);

            var newUser = _mapper.Map<User>(userDto);
            newUser.IsActive = true;
            newUser.CreatedBy = createdBy;
            newUser.CreatedAt = DateTime.UtcNow;
            newUser.PasswordHash = hashedPassword;
            newUser.RoleId = role.RoleId; 

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            await _emailService.SendUserRegistrationEmailAsync(newUser.Email, userDto.PasswordHash);

            return newUser.UserId;
        }

        public async Task<bool> DeleteUserQuery(int id, int deletedBy)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || user.IsDeleted) return false;

            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;
            user.DeletedBy = deletedBy;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<GetUserDTO>> GetAllUsersQuery()
        {
            var users = await _context.Users
                .Where(u => !u.IsDeleted)
                .Include(u => u.Role)
                .ToListAsync();

            return _mapper.Map<IEnumerable<GetUserDTO>>(users);
        }

        public async Task<GetUserDTO?> GetUserByIdQuery(int id)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserId == id && !u.IsDeleted);

            return _mapper.Map<GetUserDTO?>(user);
        }

        public async Task<IEnumerable<GetUserDTO>> GetUsersByRoleQuery(string role)
        {
            var users = await _context.Users
                .Where(u => !u.IsDeleted && u.Role.RoleName == role)
                .Include(u => u.Role)
                .ToListAsync();

            return _mapper.Map<IEnumerable<GetUserDTO>>(users);
        }

        public async Task<bool> PatchUserQuery(int id, JsonPatchDocument<UserDataDTO> patchDoc, int updatedBy)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id && !u.IsDeleted); 

            if (existingUser == null || existingUser.IsDeleted) return false;

            var userDto = _mapper.Map<UserDataDTO>(existingUser);
            patchDoc.ApplyTo(userDto);

            _mapper.Map(userDto, existingUser);
            existingUser.UpdatedAt = DateTime.UtcNow;
            existingUser.UpdatedBy = updatedBy;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUserQuery(UserDataDTO userDto, int updatedBy)
        {
            var existingUser = await _context.Users.FindAsync(userDto.Id);
            if (existingUser == null || existingUser.IsDeleted) return false;

            _mapper.Map(userDto, existingUser);
            existingUser.UpdatedAt = DateTime.UtcNow;
            existingUser.UpdatedBy = updatedBy;

            if (!string.IsNullOrEmpty(userDto.PasswordHash) || userDto.PasswordHash != "")
            {
                var passwordHasher = new PasswordHasher<UserDataDTO>();
                var hashedPassword = passwordHasher.HashPassword(userDto, userDto.PasswordHash);

                existingUser.PasswordHash = hashedPassword;
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}