using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Application.Interfaces.BookTransactions;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.LMS.Infrastructure.Repository
{
    public class TransactionHistoryRepository : GenericRepository<BorrowRequest>, ITransactionHistoryRepository
    {
        public TransactionHistoryRepository(ApplicationDBContext context): base(context) {}
        public async Task<IEnumerable<TransactionHistoryDTO>> GetAllTransactionByUserIdQuery(int id)
        {
            var transaction = await _context.ReturnRequests.Include(s => s.BorrowRequest)
                                                           .ThenInclude(s => s.Book)
                                                           .Where(s => s.BorrowRequest.UserId == id &&                                                (s.BorrowRequest.Status != Domain.Enums.RequestStatus.Pending ||
                                                           s.Status != Domain.Enums.RequestStatus.Pending))
                                                            .Select(s => new TransactionHistoryDTO
                                                            {
                                                                BorrowRequestId = s.BorrowRequestId,
                                                                CoverImageUrl = s.BorrowRequest.Book.CoverImageUrl,
                                                                Title = s.BorrowRequest.Book.Title,
                                                                IssuedDate = s.BorrowRequest.ApprovedDate,
                                                                ReturnDate = s.BorrowRequest.ReturnDate,
                                                                DueDate = s.BorrowRequest.DueDate,
                                                                Penalty = s.BorrowRequest.Penalty,
                                                                Status = s.BorrowRequest.Status
                                                            }).ToListAsync();

            return transaction;
        }

        public async Task<IEnumerable<TransactionHistoryDTO>> GetAllTransactionQuery()
        {
            var transaction = await _context.ReturnRequests.Include(s => s.BorrowRequest)
                                                                       .ThenInclude(s => s.Book)
                                                                       .Where(s => s.BorrowRequest.Status != Domain.Enums.RequestStatus.Pending ||
                                                                       s.Status != Domain.Enums.RequestStatus.Pending)
                                                                        .Select(s => new TransactionHistoryDTO
                                                                        {
                                                                            BorrowRequestId = s.BorrowRequestId,
                                                                            CoverImageUrl = s.BorrowRequest.Book.CoverImageUrl,
                                                                            Title = s.BorrowRequest.Book.Title,
                                                                            IssuedDate = s.BorrowRequest.ApprovedDate,
                                                                            ReturnDate = s.BorrowRequest.ReturnDate,
                                                                            DueDate = s.BorrowRequest.DueDate,
                                                                            Penalty = s.BorrowRequest.Penalty,
                                                                            Status = s.BorrowRequest.Status
                                                                        }).ToListAsync();

            return transaction;
        }
    }
}