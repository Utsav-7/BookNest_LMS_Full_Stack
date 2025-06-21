using LMS_Backend.LMS.Application.DTOs.GenreManagement;
using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.GenreManagement
{
    public interface IGenreRepository
    {
        public Task<IEnumerable<GenreDTO>> GetAllGenresQuery();
        public Task<GenreDTO?> GetGenreByIdQuery(int id);
        public Task<int> AddGenreQuery(CreateGenreDTO genre, int createdBy);
        public Task<int> UpdateGenreQuery(UpdateGenreDTO genre, int updatedBy);
        public Task<bool> DeleteGenreQuery(int id);
    }
}