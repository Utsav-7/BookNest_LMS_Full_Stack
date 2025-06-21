using LMS_Backend.LMS.Application.DTOs;
using LMS_Backend.LMS.Application.Interfaces;

namespace LMS_Backend.LMS.Application.Services
{
    public class StudentDashboardStatService : IStudentDashboardStatService
    {
        private readonly IStudentDashboardStatRepository _studentDashboardStatRepository;

        public StudentDashboardStatService(IStudentDashboardStatRepository studentDashboardStatRepository)
        {
            _studentDashboardStatRepository = studentDashboardStatRepository;
        }

        public async Task<StudentDashboardStatDTO> GetAllStats(int userId)
        {
            return await _studentDashboardStatRepository.GetAllStats(userId);
        }

        public async Task<List<RecentIssuedBookDto>> GetRecentIssuedBookAsync(int userId)
        {
            return await _studentDashboardStatRepository.GetRecentIssuedBookQuery(userId);
        }

        public async Task<int> GetTotalBorrowedBookAsync(int userId)
        {
            return await _studentDashboardStatRepository.GetTotalBorrowedBookQuery(userId);
        }

        public async Task<int> GetTotalReturnedBookAsync(int userId)
        {
            return await _studentDashboardStatRepository.GetTotalReturnedBookQuery(userId);
        }

        public async Task<int> GetTotalReviewsAsync(int userId)
        {
            return await _studentDashboardStatRepository.GetTotalReviewsQuery(userId);
        }

        public async Task<int> GetWishListedBookAsync(int userId)
        {
            return await _studentDashboardStatRepository.GetWishListedBookQuery(userId);
        }
    }
}