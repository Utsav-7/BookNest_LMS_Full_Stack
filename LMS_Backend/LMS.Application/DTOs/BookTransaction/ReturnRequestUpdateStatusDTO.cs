using LMS_Backend.LMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Application.DTOs.BookTransaction
{
    public class ReturnRequestUpdateStatusDTO
    {
        [Required(ErrorMessage = "Return Request ID is required.")]
        public int ReturnRequestId { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public RequestStatus Status { get; set; }
    }
}