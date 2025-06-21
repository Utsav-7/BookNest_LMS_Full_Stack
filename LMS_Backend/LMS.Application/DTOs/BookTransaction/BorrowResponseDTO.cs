using System.Text.Json.Serialization;
using LMS_Backend.LMS.Domain.Enums;
using Newtonsoft.Json.Converters;

namespace LMS_Backend.LMS.Application.DTOs.BookTransaction
{
    public class BorrowResponseDTO
    {
        public int BorrowRequestId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public RequestStatus Status { get; set; }
        public DateOnly RequestDate { get; set; }
        public DateOnly? ApprovedDate { get; set; }
        public DateOnly? DueDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
    }
}