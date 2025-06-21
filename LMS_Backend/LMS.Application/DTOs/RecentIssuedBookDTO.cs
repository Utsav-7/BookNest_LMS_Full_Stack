namespace LMS_Backend.LMS.Application.DTOs
{
    public class RecentIssuedBookDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string StudentName { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly DueDate { get; set; }
    }
}