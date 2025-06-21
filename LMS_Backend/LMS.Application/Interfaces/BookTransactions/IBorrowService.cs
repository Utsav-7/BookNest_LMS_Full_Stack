using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Application.DTOs.User;
using LMS_Backend.LMS.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface IBorrowService
    {
        public Task<IEnumerable<BorrowResponseDTO>> GetAllBorrowRequestsAsync();
        public Task<IEnumerable<BorrowResponseDTO>?> GetBorrowRequestByUserIdAsync(int id);
        public Task<BorrowResponseDTO?> GetBorrowRequestByIdAsync(int id);
        public Task<bool> AddBorrowRequestAsync(BorrowRequestCreateDTO request, int createdBy);
        public Task<bool> PatchBorrowRequestAsync(int id, JsonPatchDocument<BorrowRequestUpdateStatusDTO> patchDoc,int updatedBy);
        public Task<bool> DeleteBorrowRequestAsync(int id, int deletedBy);
    }
}