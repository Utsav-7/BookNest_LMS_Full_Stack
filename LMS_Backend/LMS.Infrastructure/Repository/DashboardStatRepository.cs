using LMS_Backend.LMS.Application.DTOs;
using LMS_Backend.LMS.Application.Interfaces;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.LMS.Infrastructure.Repository
{
    public class DashboardStatRepository : GenericRepository<Book>, IDashboardStatRepository
    {
        public DashboardStatRepository(ApplicationDBContext context): base(context){}

        public async Task<DashboardsStatDTO> GetAllStatsQuery()
        {
            var totalBooksTask = await GetTotalBooksQuery();
            var totalReturnedBooksTask = await GetTotalReturnedBooksQuery();
            var totalBorrowedBooksTask = await GetTotalBorrowedBooksQuery();
            var totalStudentsTask = await GetTotalStudentsQuery();
            var totalLibrariansTask = await GetTotalLibrariansQuery();
            var totalGenresTask =  await GetTotalGenresQuery();
            var totalReviewsTask = await GetTotalReviewsQuery();
            var recentIssuedBooksTask = await GetRecentIssuedBooksQuery();
            var totalBookCopies = await GetTotalCopies();

            return new DashboardsStatDTO
            {
                Books =  totalBooksTask,
                BorrowedBooks = totalBorrowedBooksTask,
                ReturnedBooks = totalReturnedBooksTask,
                Students = totalStudentsTask,
                Librarians = totalLibrariansTask,
                Genres = totalGenresTask,
                Reviews = totalReviewsTask,
                TotalCopies = totalBookCopies,
                RecentIssuedBooks = recentIssuedBooksTask,
            };
        }

        public async Task<List<RecentIssuedBookDto>> GetRecentIssuedBooksQuery(int count = 5)
        {
            var recentIssuedBooks = await _context.BorrowRequests
                .Where(br => br.Status == Domain.Enums.RequestStatus.Approved) 
                .OrderByDescending(br => br.ApprovedDate) 
                .Take(count) 
                .Include(br => br.Book) 
                .Include(br => br.User) 
                .Select(br => new RecentIssuedBookDto
                {
                    Id = br.Book.BookId.ToString(),
                    Title = br.Book.Title,
                    StudentName = br.User.FirstName + " " + br.User.LastName,
                    IssueDate = (DateOnly)br.ApprovedDate,
                    DueDate = (DateOnly)br.DueDate
                })
                .ToListAsync();

            return recentIssuedBooks;
        }
        public async Task<int> GetTotalBooksQuery()
        {
            int total = await _context.Books.CountAsync();
            return total;
        }

        public async Task<int> GetTotalCopies()
        {
            int total = await _context.Books.Select(s => s.TotalCopies).SumAsync();
            return total;
        }

        public async Task<int> GetTotalBorrowedBooksQuery()
        {
            int total = await _context.BorrowRequests.CountAsync();
            return total;
        }

        public async Task<int> GetTotalGenresQuery()
        {
            int total = await _context.Genres.CountAsync();
            return total;
        }

        public async Task<int> GetTotalLibrariansQuery()
        {
            int total = await _context.Users.Where(s => s.RoleId == 2).CountAsync();
            return total;
        }

        public async Task<int> GetTotalReturnedBooksQuery()
        {
            int total = await _context.ReturnRequests.Where(s => s.Status == Domain.Enums.RequestStatus.Approved || s.Status == Domain.Enums.RequestStatus.Completed).CountAsync();
            return total;
        }

        public async Task<int> GetTotalReviewsQuery()
        {
            int total = await _context.BookReviews.CountAsync();
            return total;
        }

        public async Task<int> GetTotalStudentsQuery()
        {
            int total = await _context.Users.Where(s => s.RoleId == 3).CountAsync();
            return total;
        }
    }
}