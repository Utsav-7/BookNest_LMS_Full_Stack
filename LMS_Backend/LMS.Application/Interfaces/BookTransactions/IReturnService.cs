using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface IReturnService
    {
        public Task<ReturnResponseDTO?> GetReturnRequestByIdAsync(int id);
        public Task<IEnumerable<ReturnResponseDTO>> GetAllReturnRequestsAsync();
        public Task<IEnumerable<ReturnResponseDTO>> GetReturnRequestsByUserIdAsync(int userId);
        public Task<bool> AddReturnRequestAsync(ReturnRequestCreateDTO request, int createdBy);
        public Task<bool> PatchReturnRequestAsync(int id, JsonPatchDocument<ReturnRequestUpdateStatusDTO> patchDoc, int updatedBy);
        public Task<bool> DeleteReturnRequestAsync(int id, int deletedBy);
    }
}