using System.ComponentModel.DataAnnotations;
using LMS_Backend.LMS.Domain.Enums;

namespace LMS_Backend.LMS.Domain.Entities
{
    public class BorrowRequest : BaseEntity, IValidatableObject
    {
        [Key]
        public int BorrowRequestId { get; set; }

        [Required(ErrorMessage = "Book ID is required")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public RequestStatus Status { get; set; }

        [Required(ErrorMessage = "Request date is required")]
        public DateOnly RequestDate { get; set; }

        public int? ApprovedBy { get; set; }
        public DateOnly? ApprovedDate { get; set; }

        public DateOnly? DueDate { get; set; }
        public DateOnly? ReturnDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Penalty cannot be negative")]
        public decimal? Penalty { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }

        // Navigation properties
        public Book Book { get; set; }
        public User User { get; set; }
        public ReturnRequest? ReturnRequest { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            if (RequestDate > today)
            {
                yield return new ValidationResult("Request date cannot be in the future", new[] { nameof(RequestDate) });
            }

            if (ApprovedDate.HasValue && ApprovedDate.Value < RequestDate)
            {
                yield return new ValidationResult("Approved date cannot be before request date", new[] { nameof(ApprovedDate) });
            }

            if (DueDate.HasValue && ApprovedDate.HasValue && DueDate.Value < ApprovedDate.Value)
            {
                yield return new ValidationResult("Due date cannot be before approved date", new[] { nameof(DueDate) });
            }

            if (ReturnDate.HasValue && ReturnDate.Value < RequestDate)
            {
                yield return new ValidationResult("Return date cannot be before request date", new[] { nameof(ReturnDate) });
            }
        }
    }
}