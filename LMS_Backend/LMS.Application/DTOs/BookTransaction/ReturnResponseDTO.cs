using LMS_Backend.LMS.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LMS_Backend.LMS.Application.DTOs.BookTransaction
{
    public class ReturnResponseDTO
    {
        public int ReturnRequestId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public RequestStatus Status { get; set; }
        public DateOnly RequestDate { get; set; }
        public DateOnly? ApprovedDate { get; set; }
        public DateOnly? DueDate { get; set; }
    }
}