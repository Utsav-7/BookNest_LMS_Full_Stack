namespace LMS_Backend.LMS.Application.DTOs
{
    public class StudentDashboardStatDTO
    {
        public int TotalReview { get; set; }
        public int WishListedBook { get; set; }
        public int BorrowedBook { get; set; }
        public int ReturnedBook { get; set; }
        public List<RecentIssuedBookDto>? RecentIssuedBooks { get; set; }
    }
}