using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Application.Interfaces.BookTransactions;
using LMS_Backend.LMS.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRequestRepository _borrowRequestRepository;

        public BorrowService(IBorrowRequestRepository borrowRequestRepository)
        {
            _borrowRequestRepository = borrowRequestRepository;
        }

        public async Task<bool> AddBorrowRequestAsync(BorrowRequestCreateDTO request, int createdBy)
        {
            return await _borrowRequestRepository.AddBorrowRequestQuery(request, createdBy);
        }

        public async Task<bool> DeleteBorrowRequestAsync(int id, int deletedBy)
        {
            return await _borrowRequestRepository.DeleteBorrowRequestQuery(id, deletedBy);
        }

        public async Task<IEnumerable<BorrowResponseDTO>> GetAllBorrowRequestsAsync()
        {
            return await _borrowRequestRepository.GetAllBorrowRequestsQuery();
        }

        public async Task<BorrowResponseDTO?> GetBorrowRequestByIdAsync(int id)
        {
            return await _borrowRequestRepository.GetBorrowRequestByIdQuery(id);
        }

        public async Task<IEnumerable<BorrowResponseDTO>?> GetBorrowRequestByUserIdAsync(int id)
        {
            return await _borrowRequestRepository.GetBorrowRequestByUserIdQuery(id);
        }

        public async Task<bool> PatchBorrowRequestAsync(int id, JsonPatchDocument<BorrowRequestUpdateStatusDTO> patchDoc, int updatedBy)
        {
            return await _borrowRequestRepository.PatchBorrowRequestQuery(id, patchDoc, updatedBy);
        }
    }
}