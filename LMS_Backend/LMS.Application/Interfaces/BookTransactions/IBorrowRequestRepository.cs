using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Application.DTOs.User;
using LMS_Backend.LMS.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface IBorrowRequestRepository
    {
        public Task<IEnumerable<BorrowResponseDTO>> GetAllBorrowRequestsQuery();
        public Task<IEnumerable<BorrowResponseDTO>?> GetBorrowRequestByUserIdQuery(int id);
        public Task<BorrowResponseDTO?> GetBorrowRequestByIdQuery(int id);
        public Task<bool> AddBorrowRequestQuery(BorrowRequestCreateDTO request, int createdBy);
        public Task<bool> PatchBorrowRequestQuery(int id, JsonPatchDocument<BorrowRequestUpdateStatusDTO> patchDoc,int updatedBy);
        public Task<bool> DeleteBorrowRequestQuery(int id, int deletedBy);
    }
}