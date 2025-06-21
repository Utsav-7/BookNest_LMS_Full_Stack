using System.Text.Json.Serialization;
using LMS_Backend.LMS.Domain.Enums;
using Newtonsoft.Json.Converters;

namespace LMS_Backend.LMS.Application.DTOs.BookTransaction
{
    public class TransactionHistoryDTO
    {
        public int BorrowRequestId { get; set; }
        public string Title { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateOnly? IssuedDate { get; set; }
        public DateOnly? DueDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public decimal? Penalty { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public RequestStatus Status { get; set; }
    }
}