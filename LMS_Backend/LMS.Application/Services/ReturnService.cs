using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Application.Interfaces.BookTransactions;
using LMS_Backend.LMS.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Services
{
    public class ReturnService : IReturnService
    {
        private readonly IReturnRequestRepository _returnRequestRepository;

        public ReturnService(IReturnRequestRepository returnRequestRepository)
        {
            _returnRequestRepository = returnRequestRepository;
        }

        public async Task<bool> AddReturnRequestAsync(ReturnRequestCreateDTO request, int createdBy)
        {
            return await _returnRequestRepository.AddReturnRequestQuery(request, createdBy);
        }

        public async Task<bool> DeleteReturnRequestAsync(int id, int deletedBy)
        {
            return await _returnRequestRepository.DeleteReturnRequestQuery(id, deletedBy);
        }

        public async Task<IEnumerable<ReturnResponseDTO>> GetAllReturnRequestsAsync()
        {
            return await _returnRequestRepository.GetAllReturnRequestsQuery();
        }

        public async Task<ReturnResponseDTO?> GetReturnRequestByIdAsync(int id)
        {
            return await _returnRequestRepository.GetReturnRequestByIdQuery(id);
        }

        public async Task<IEnumerable<ReturnResponseDTO>> GetReturnRequestsByUserIdAsync(int userId)
        {
            return await _returnRequestRepository.GetReturnRequestsByUserIdQuery(userId);
        }

        public async Task<bool> PatchReturnRequestAsync(int id, JsonPatchDocument<ReturnRequestUpdateStatusDTO> patchDoc, int updatedBy)
        {
            return await _returnRequestRepository.PatchReturnRequestQuery(id, patchDoc, updatedBy);
        }
    }
}