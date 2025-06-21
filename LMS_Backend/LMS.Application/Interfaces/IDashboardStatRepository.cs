using LMS_Backend.LMS.Application.DTOs;

namespace LMS_Backend.LMS.Application.Interfaces
{
    public interface IDashboardStatRepository
    {
        public Task<DashboardsStatDTO> GetAllStatsQuery();

        public Task<int> GetTotalBooksQuery();
        public Task<int> GetTotalBorrowedBooksQuery();
        public Task<int> GetTotalReturnedBooksQuery();
        public Task<int> GetTotalStudentsQuery();
        public Task<int> GetTotalLibrariansQuery();
        public Task<int> GetTotalGenresQuery();
        public Task<int> GetTotalReviewsQuery();
        public Task<int> GetTotalCopies();
        public Task<List<RecentIssuedBookDto>> GetRecentIssuedBooksQuery(int count = 5);
    }
}