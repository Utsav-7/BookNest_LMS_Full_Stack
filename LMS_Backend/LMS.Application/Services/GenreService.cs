using LMS_Backend.LMS.Application.DTOs.GenreManagement;
using LMS_Backend.LMS.Application.Interfaces.GenreManagement;

namespace LMS_Backend.LMS.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<int> AddGenreAsync(CreateGenreDTO createGenreDto, int createdBy)
        {
            return await _genreRepository.AddGenreQuery(createGenreDto, createdBy);
        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            return await _genreRepository.DeleteGenreQuery(id);
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenresAsync()
        {
            return await _genreRepository.GetAllGenresQuery();
        }

        public async Task<GenreDTO?> GetGenreByIdAsync(int id)
        {
            return await _genreRepository.GetGenreByIdQuery(id);
        }

        public async Task<int> UpdateGenreAsync(UpdateGenreDTO updateGenreDto, int updatedBy)
        {
            return await _genreRepository.UpdateGenreQuery(updateGenreDto, updatedBy);
        }
    }
}