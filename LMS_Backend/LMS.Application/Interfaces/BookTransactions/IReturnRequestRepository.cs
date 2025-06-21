using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface IReturnRequestRepository
    {
        public Task<ReturnResponseDTO?> GetReturnRequestByIdQuery(int id);
        public Task<IEnumerable<ReturnResponseDTO>> GetAllReturnRequestsQuery();
        public Task<IEnumerable<ReturnResponseDTO>> GetReturnRequestsByUserIdQuery(int userId);
        public Task<bool> AddReturnRequestQuery(ReturnRequestCreateDTO request, int createdBy);
        public Task<bool> PatchReturnRequestQuery(int id, JsonPatchDocument<ReturnRequestUpdateStatusDTO> patchDoc, int updatedBy);
        public Task<bool> DeleteReturnRequestQuery(int id, int deletedBy);
    }
}