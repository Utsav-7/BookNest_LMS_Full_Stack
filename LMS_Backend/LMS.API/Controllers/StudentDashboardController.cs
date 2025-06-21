using System.Security.Claims;
using Asp.Versioning;
using LMS_Backend.LMS.Application.Interfaces.UserManagement;
using LMS_Backend.LMS.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS_Backend.LMS.Application.Services;
using Microsoft.AspNetCore.Authorization;
using LMS_Backend.LMS.Common.Exceptions;

namespace LMS_Backend.LMS.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/dashboard")]
    [Produces("application/json")]
    public class StudentDashboardController : ControllerBase
    {
        private readonly IStudentDashboardStatService _studentDashboardStatService;

        public StudentDashboardController(IStudentDashboardStatService studentDashboardStatService)
        {
            _studentDashboardStatService = studentDashboardStatService;
        }

        private int GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpGet("student-stats")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> DashboardStats()
        {
            try
            {
                var loggedInUser = GetLoggedInUserId();
                var statsData = await _studentDashboardStatService.GetAllStats(loggedInUser);
                return Ok(new { success = true, message = "Data fetched successfully", data = statsData });
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
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "An error occurred while fetching user profile", error = ex.Message });
            }
        }
    }
}