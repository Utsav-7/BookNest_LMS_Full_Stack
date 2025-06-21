using LMS_Backend.LMS.Application.DTOs.BookTransaction;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface ITransactionHistoryService
    {
        public Task<IEnumerable<TransactionHistoryDTO>> GetAllTransactionAsync();
        public Task<IEnumerable<TransactionHistoryDTO>> GetAllTransactionByUserIdAsync(int id);
    }
}