using System.Security.Claims;
using Asp.Versioning;
using LMS_Backend.LMS.Application.DTOs.GenreManagement;
using LMS_Backend.LMS.Application.Interfaces.GenreManagement;
using LMS_Backend.LMS.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_Backend.LMS.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/genre")]
    [Produces("application/json")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        private int GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Administrator, Librarian")]

        public async Task<IActionResult> GetAllGenres()
        {
            try
            {
                var result = await _genreService.GetAllGenresAsync();
                return Ok(new { success = true, message = "Genres fetched successfully.", data = result });
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet("get-by-id")]
        [Authorize(Roles = "Administrator, Librarian")]
        public async Task<IActionResult> GetGenreById([FromQuery]int id)
        {
            try
            {
                var result = await _genreService.GetGenreByIdAsync(id);
                if (result == null)
                    return NotFound(new { success = false, message = "Genre not found." });

                return Ok(new { success = true, message = "Genre fetched successfully.", data = result });
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpPost("create")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDTO createGenreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = "Invalid input", errors = ModelState });

            try
            {
                var loggedInUser = GetLoggedInUserId();
                var genreId = await _genreService.AddGenreAsync(createGenreDto, loggedInUser);
                return Ok(new { success = true, message = "Genre created successfully.", genreId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpPut("update")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreDTO updateGenreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = "Invalid input", errors = ModelState });

            try
            {
                var loggedInUser = GetLoggedInUserId();
                var genreId = await _genreService.UpdateGenreAsync(updateGenreDto, loggedInUser);
                return Ok(new { success = true, message = "Genre updated successfully.", genreId });
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteGenre([FromQuery]int id)
        {
            try
            {
                var result = await _genreService.DeleteGenreAsync(id);
                if (!result)
                    return NotFound(new { success = false, message = "Genre not found." });

                return Ok(new { success = true, message = "Genre deleted successfully." });
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}