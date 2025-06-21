using LMS_Backend.LMS.Application.DTOs;
using LMS_Backend.LMS.Application.Interfaces;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.LMS.Infrastructure.Repository
{
    public class StudentDashboardStatRepository : GenericRepository<BorrowRequest>, IStudentDashboardStatRepository
    {
        public StudentDashboardStatRepository(ApplicationDBContext context): base(context) {}
        public async Task<StudentDashboardStatDTO> GetAllStats(int userId)
        {
            var totalReturnedBooksTask = await GetTotalReturnedBookQuery(userId);
            var totalBorrowedBooksTask = await GetTotalBorrowedBookQuery(userId);
            var totalWishlistedBooksTask = await GetWishListedBookQuery(userId);
            var totalReviewsTask = await GetTotalReviewsQuery(userId);
            var recentIssuedBooksTask = await GetRecentIssuedBookQuery(userId);

            return new StudentDashboardStatDTO
            {
                ReturnedBook= totalReturnedBooksTask,
                BorrowedBook= totalBorrowedBooksTask,
                WishListedBook = totalWishlistedBooksTask,
                TotalReview = totalReviewsTask,
                RecentIssuedBooks = recentIssuedBooksTask,
            };
        }

        public async Task<List<RecentIssuedBookDto>> GetRecentIssuedBookQuery(int userId)
        {
            var recentIssuedBooks = await _context.BorrowRequests
                           .Where(br => br.Status == Domain.Enums.RequestStatus.Approved && br.UserId == userId)
                           .OrderByDescending(br => br.ApprovedDate)
                           .Take(5)
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

        public async Task<int> GetTotalBorrowedBookQuery(int userId)
        {
            return await _context.BorrowRequests.Where(s => s.UserId == userId).CountAsync();
        }

        public async Task<int> GetTotalReturnedBookQuery(int userId)
        {
            return await _context.ReturnRequests.Include(s => s.BorrowRequest).Where(s => s.BorrowRequest.UserId == userId).CountAsync();
        }

        public async Task<int> GetTotalReviewsQuery(int userId)
        {
            return await _context.BookReviews.Where(s => s.UserId == userId).CountAsync();
        }

        public async Task<int> GetWishListedBookQuery(int userId)
        {
            return await _context.WishLists.Where(s => s.UserId == userId && !s.IsAvailable).CountAsync();
        }
    }
}