namespace LMS_Backend.LMS.Application.DTOs
{
    public class DashboardsStatDTO
    {
        public int Books { get; set; }
        public int BorrowedBooks { get; set; }
        public int ReturnedBooks { get; set; }
        public int Students { get; set; }
        public int Librarians { get; set; }
        public int Genres { get; set; }
        public int Reviews { get; set; }
        public int TotalCopies { get; set; }
        public List<RecentIssuedBookDto>? RecentIssuedBooks { get; set; }
    }
}