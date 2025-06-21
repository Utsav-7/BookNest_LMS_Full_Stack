using LMS_Backend.LMS.Application.DTOs.BookManagement;

namespace LMS_Backend.LMS.Application.Interfaces.PaginationServices
{
    public interface IPaginationRepository
    {
        public Task<IEnumerable<GetBookDTO>> GetPageQuery(int bookPerPage, int pageNo);
    }
}