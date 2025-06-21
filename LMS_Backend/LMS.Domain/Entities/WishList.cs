using System;
using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Domain.Entities
{
    public class WishList
    {
        [Key]
        public int WishListId { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Book ID is required")]
        public int BookId { get; set; }

        public bool Notified { get; set; } = false;

        public bool IsAvailable { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Book Book { get; set; }
    }
}