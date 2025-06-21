using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Application.Interfaces.BookTransactions;

namespace LMS_Backend.LMS.Application.Services
{
    public class TransactionService : ITransactionHistoryService
    {
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;

        public TransactionService(ITransactionHistoryRepository transactionHistoryRepository)
        {
            _transactionHistoryRepository = transactionHistoryRepository;
        }
        public async Task<IEnumerable<TransactionHistoryDTO>> GetAllTransactionAsync()
        {
            return await _transactionHistoryRepository.GetAllTransactionQuery();
        }

        public async Task<IEnumerable<TransactionHistoryDTO>> GetAllTransactionByUserIdAsync(int id)
        {
            return await _transactionHistoryRepository.GetAllTransactionByUserIdQuery(id);
        }
    }
}