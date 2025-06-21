using System.Security.Claims;
using Asp.Versioning;
using LMS_Backend.LMS.Application.Interfaces.WishListAndNotification;
using LMS_Backend.LMS.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS_Backend.LMS.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/wishlist")]
    [Produces("application/json")]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistAndNotificationService _wishlistAndNotificationService;

        public WishlistController(IWishlistAndNotificationService wishlistAndNotificationService)
        {
            _wishlistAndNotificationService = wishlistAndNotificationService;
        }

        private int GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpGet("my-list")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetWishlist()
        {
            try
            {
                var loggedInUser = GetLoggedInUserId();
                var wishList = await _wishlistAndNotificationService.GetUserWishlistAsync(loggedInUser);
                return Ok(new { success = true, message = "Wishlist fetched successfully.", data = wishList });
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
                return StatusCode(500, new { success = false, message = $"Error fetching wishlist: {ex.Message}" });
            }
        }

        [HttpPost("add-to-wishlist")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> AddToWishlist([FromQuery]int bookId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdBy = GetLoggedInUserId();
                var status = await _wishlistAndNotificationService.AddToWishlistAsync(createdBy, bookId);
                return Ok(new { success = true, message = "Book added successfully in wishlist.", data = status });
            }
            catch (AlreadyExistsException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"{ex.Message}" });
            }
        }

        [HttpPost("remove")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> RemoveFromWishList([FromQuery] int wishlistId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdBy = GetLoggedInUserId();
                var status = await _wishlistAndNotificationService.RemoveFromWishlistAsync(wishlistId);
                return Ok(new { success = true, message = "Book removed successfully from wishlist.", data = status });
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
                return StatusCode(500, new { success = false, message = $"Error while removing from wishlist: {ex.Message}" });
            }
        }
    }
}