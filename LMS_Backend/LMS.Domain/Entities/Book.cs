using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Domain.Entities
{
    public class Book : BaseEntity
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [StringLength(20, ErrorMessage = "ISBN cannot exceed 20 characters")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Book title is required")]
        [StringLength(200, ErrorMessage = "Book title cannot exceed 200 characters")]
        public string Title { get; set; }

        [Range(1000, 2100, ErrorMessage = "Please enter a valid publication year")]
        public int PublicationYear { get; set; }

        [StringLength(100, ErrorMessage = "Publisher name cannot exceed 100 characters")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public int GenreId { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }

        public string? CoverImageUrl { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Total copies must be a non-negative number")]
        public int TotalCopies { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Available copies must be a non-negative number")]
        public int AvailableCopies { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int? DeletedBy { get; set; }

        // Navigation properties
        public Genre Genre { get; set; }
        public ICollection<WishList> WishLists { get; set; } = new List<WishList>();
        public ICollection<BorrowRequest> BorrowRequests { get; set; } = new List<BorrowRequest>();
        public ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();
    }
}