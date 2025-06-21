using LMS_Backend.LMS.Application.DTOs.GenreManagement;

namespace LMS_Backend.LMS.Application.Interfaces.GenreManagement
{
    public interface IGenreService
    {
        public Task<IEnumerable<GenreDTO>> GetAllGenresAsync();
        public Task<GenreDTO?> GetGenreByIdAsync(int id);
        public Task<int> AddGenreAsync(CreateGenreDTO createGenreDto, int createdBy);
        public Task<int> UpdateGenreAsync(UpdateGenreDTO updateGenreDto, int updatedBy);
        public Task<bool> DeleteGenreAsync(int id);
    }
}