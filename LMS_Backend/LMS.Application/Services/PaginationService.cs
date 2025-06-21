using LMS_Backend.LMS.Application.DTOs.BookManagement;
using LMS_Backend.LMS.Application.Interfaces.PaginationServices;

namespace LMS_Backend.LMS.Application.Services
{
    public class PaginationService : IPaginationService
    {
        private readonly IPaginationRepository _paginationRepository;

        public PaginationService(IPaginationRepository paginationRepository)
        {
            _paginationRepository = paginationRepository;
        }

        public async Task<IEnumerable<GetBookDTO>> GetPageAsync(int bookPerPage, int pageNo)
        {
            return await _paginationRepository.GetPageQuery(bookPerPage, pageNo);
        }
    }
}
