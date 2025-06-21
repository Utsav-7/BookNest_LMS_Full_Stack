using LMS_Backend.LMS.Application.DTOs;

namespace LMS_Backend.LMS.Application.Interfaces
{
    public interface IStudentDashboardStatService
    {
        public Task<StudentDashboardStatDTO> GetAllStats(int userId);
        public Task<int> GetTotalReviewsAsync(int userId);
        public Task<int> GetWishListedBookAsync(int userId);
        public Task<int> GetTotalBorrowedBookAsync(int userId);
        public Task<int> GetTotalReturnedBookAsync(int userId);
        public Task<List<RecentIssuedBookDto>> GetRecentIssuedBookAsync(int userId);
    }
}