using LMS_Backend.LMS.Application.DTOs;

namespace LMS_Backend.LMS.Application.Interfaces
{
    public interface IDashboardStatService
    {
        public Task<DashboardsStatDTO> GetAllStatsAsync();
        public Task<int> GetTotalBooksAsync();
        public Task<int> GetTotalBorrowedBooksAsync();
        public Task<int> GetTotalReturnedBooksAsync();
        public Task<int> GetTotalStudentsAsync();
        public Task<int> GetTotalLibrariansAsync();
        public Task<int> GetTotalGenresAsync();
        public Task<int> GetTotalReviewsAsync();
        public Task<List<RecentIssuedBookDto>> GetRecentIssuedBooksAsync(int count = 5);
    }
}
