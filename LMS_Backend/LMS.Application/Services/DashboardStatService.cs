using LMS_Backend.LMS.Application.DTOs;
using LMS_Backend.LMS.Application.Interfaces;

namespace LMS_Backend.LMS.Application.Services
{
    public class DashboardStatService : IDashboardStatService
    {
        private readonly IDashboardStatRepository _dashboardStatRepository;

        public DashboardStatService(IDashboardStatRepository dashboardStatRepository)
        {
            _dashboardStatRepository = dashboardStatRepository;
        }

        public async Task<DashboardsStatDTO> GetAllStatsAsync()
        {
            return await _dashboardStatRepository.GetAllStatsQuery();
        }

        public async Task<List<RecentIssuedBookDto>> GetRecentIssuedBooksAsync(int count = 5)
        {
            return await _dashboardStatRepository.GetRecentIssuedBooksQuery(count);
        }

        public async Task<int> GetTotalBooksAsync()
        {
            return await _dashboardStatRepository.GetTotalBooksQuery();
        }

        public async Task<int> GetTotalBorrowedBooksAsync()
        {
            return await _dashboardStatRepository.GetTotalBorrowedBooksQuery();
        }

        public async Task<int> GetTotalGenresAsync()
        {
            return await _dashboardStatRepository.GetTotalGenresQuery();
        }

        public async Task<int> GetTotalLibrariansAsync()
        {
            return await _dashboardStatRepository.GetTotalLibrariansQuery();
        }

        public async Task<int> GetTotalReturnedBooksAsync()
        {
            return await _dashboardStatRepository.GetTotalReturnedBooksQuery();
        }

        public async Task<int> GetTotalStudentsAsync()
        {
            return await _dashboardStatRepository.GetTotalStudentsQuery();
        }

        public async Task<int> GetTotalReviewsAsync()
        {
            return await _dashboardStatRepository.GetTotalReviewsQuery();
        }
    }
}
