using LMS_Backend.LMS.Application.DTOs.BookManagement;

namespace LMS_Backend.LMS.Application.Interfaces.PaginationServices
{
    public interface IPaginationService
    {
        public Task<IEnumerable<GetBookDTO>> GetPageAsync(int bookPerPage, int pageNo);
    }
}