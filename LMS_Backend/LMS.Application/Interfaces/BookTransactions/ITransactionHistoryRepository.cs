using LMS_Backend.LMS.Application.DTOs.BookTransaction;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface ITransactionHistoryRepository
    {
        public Task<IEnumerable<TransactionHistoryDTO>> GetAllTransactionQuery();
        public Task<IEnumerable<TransactionHistoryDTO>> GetAllTransactionByUserIdQuery(int id);
    }
}