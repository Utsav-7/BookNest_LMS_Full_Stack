using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LMS_Backend.LMS.Domain.Enums;

namespace LMS_Backend.LMS.Domain.Entities
{
    public class ReturnRequest : BaseEntity, IValidatableObject
    {
        [Key]
        public int ReturnRequestId { get; set; }

        [Required(ErrorMessage = "Borrow ID is required")]
        public int BorrowRequestId { get; set; }

        [Required(ErrorMessage = "RequestedBy is required")]
        public int RequestedBy { get; set; }

        [Required(ErrorMessage = "RequestedAt date is required")]
        public DateOnly RequestedDate { get; set; }

        public int? ApprovedBy { get; set; }

        public DateOnly? ApprovedDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public RequestStatus Status { get; set; }
        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }

        // Navigation properties
        public BorrowRequest BorrowRequest { get; set; }

        // Custom date validations
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            if (RequestedDate > today)
            {
                yield return new ValidationResult(
                    "Requested date cannot be in the future",
                    new[] { nameof(RequestedDate) });
            }

            if (ApprovedDate.HasValue)
            {
                if (ApprovedDate.Value < RequestedDate)
                {
                    yield return new ValidationResult(
                        "Approved date cannot be before requested date",
                        new[] { nameof(ApprovedDate) });
                }

                if (ApprovedDate.Value > today)
                {
                    yield return new ValidationResult(
                        "Approved date cannot be in the future",
                        new[] { nameof(ApprovedDate) });
                }
            }
        }
    }
}