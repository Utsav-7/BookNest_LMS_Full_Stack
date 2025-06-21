using AutoMapper;
using LMS_Backend.LMS.Application.DTOs.GenreManagement;
using LMS_Backend.LMS.Application.Interfaces.GenreManagement;
using LMS_Backend.LMS.Common.Exceptions;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.LMS.Infrastructure.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly IMapper _mapper;

        public GenreRepository(ApplicationDBContext context, IMapper mapper): base(context) 
        {
            _mapper = mapper;
        }

        public async Task<int> AddGenreQuery(CreateGenreDTO genreDto, int createdBy)
        {
            var existingGenre = await _context.Genres.FirstOrDefaultAsync(s => s.GenreName == genreDto.GenreName);

            if (existingGenre != null)
                throw new AlreadyExistsException<string>("Genre already exists.");

            var genre = _mapper.Map<Genre>(genreDto);
            genre.CreatedBy = createdBy;
            genre.CreatedAt = DateTime.UtcNow;

            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();

            return genre.GenreId;
        }

        public async Task<bool> DeleteGenreQuery(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
                throw new DataNotFoundException<string>("Genre not found.");

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenresQuery()
        {
            var genres = await _context.Genres.ToListAsync();
            return _mapper.Map<IEnumerable<GenreDTO>>(genres);
        }

        public async Task<GenreDTO?> GetGenreByIdQuery(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
                return null;

            return _mapper.Map<GenreDTO>(genre);
        }

        public async Task<int> UpdateGenreQuery(UpdateGenreDTO updateDto, int updatedBy)
        {
            var genre = await _context.Genres.FindAsync(updateDto.GenreId);
            if (genre == null)
                throw new DataNotFoundException<string>("Genre not found.");

            _mapper.Map(updateDto, genre);
            genre.UpdatedBy = updatedBy;
            genre.UpdatedAt = DateTime.UtcNow;

            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();

            return genre.GenreId;
        }
    }
}