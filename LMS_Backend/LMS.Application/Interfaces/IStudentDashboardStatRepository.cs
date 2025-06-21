using LMS_Backend.LMS.Application.DTOs;

namespace LMS_Backend.LMS.Application.Interfaces
{
    public interface IStudentDashboardStatRepository
    {
        public Task<StudentDashboardStatDTO> GetAllStats(int id);
        public Task<int> GetTotalReviewsQuery(int userId);
        public Task<int> GetWishListedBookQuery(int userId);
        public Task<int> GetTotalBorrowedBookQuery(int userId);
        public Task<int> GetTotalReturnedBookQuery(int userId);
        public Task<List<RecentIssuedBookDto>> GetRecentIssuedBookQuery(int userId);
    }
}
