using LMS_Backend.LMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Application.DTOs.BookTransaction
{
    public class BorrowRequestUpdateStatusDTO: BorrowRequestCreateDTO
    {
        [Required(ErrorMessage = "Status is required.")]
        public RequestStatus Status { get; set; }
    }
}