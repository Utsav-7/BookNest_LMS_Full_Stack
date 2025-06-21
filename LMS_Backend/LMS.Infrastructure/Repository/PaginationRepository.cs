using LMS_Backend.LMS.Application.DTOs.BookManagement;
using LMS_Backend.LMS.Application.Interfaces.PaginationServices;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.LMS.Infrastructure.Repository
{
    public class PaginationRepository : GenericRepository<Book>, IPaginationRepository
    {
        public PaginationRepository(ApplicationDBContext context): base(context){}

        public async Task<IEnumerable<GetBookDTO>> GetPageQuery(int bookPerPage, int pageNo)
        {
            var bookList = await _context.Books
                .Where(b => !b.IsDeleted)
                .Include(b => b.Genre)
                .OrderBy(b => b.Title)
                .Skip((pageNo - 1) * bookPerPage)
                .Take(bookPerPage)
                .Select(b => new GetBookDTO
                {
                    id = b.BookId,
                    Title = b.Title,
                    Author = b.Author,
                    GenreName = b.Genre.GenreName,
                    AvailableCopies = b.AvailableCopies,
                    TotalCopies = b.TotalCopies,
                    PublicationYear = b.PublicationYear,
                    Publisher = b.Publisher,
                    ISBN = b.ISBN,
                    Description = b.Description,
                    CoverImageUrl = b.CoverImageUrl
                })
                .ToListAsync();

            return bookList;
        }

    }
}