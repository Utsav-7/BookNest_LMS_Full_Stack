using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Application.DTOs.GenreManagement
{
    public class UpdateGenreDTO
    {
        [Required]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Genre name is required")]
        [MaxLength(100, ErrorMessage = "Genre name cannot exceed 100 characters")]
        public string GenreName { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }
    }
}