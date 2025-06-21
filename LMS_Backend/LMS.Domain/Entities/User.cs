using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Domain.Entities
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        [MaxLength(10, ErrorMessage = "Mobile number cannot exceed 10 characters")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Password hash is required")]
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public string? ProfileImageUrl { get; set; }

        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }

        // Navigation properties
        public Role Role { get; set; }
        public ICollection<WishList> WishLists { get; set; }
        public ICollection<BorrowRequest> BorrowRequests { get; set; }
        public ICollection<BookReview> Reviews { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<AuditLog> Logs { get; set; }
    }
}