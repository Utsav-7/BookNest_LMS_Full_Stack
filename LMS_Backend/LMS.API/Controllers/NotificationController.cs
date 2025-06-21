using LMS_Backend.LMS.Application.Interfaces.WishListAndNotification;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using LMS_Backend.LMS.Common.Exceptions;

namespace LMS_Backend.LMS.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/notifications")]
    [Produces("application/json")]
    public class NotificationController : ControllerBase
    {
        private readonly IWishlistAndNotificationService _wishlistAndNotificationService;

        public NotificationController(IWishlistAndNotificationService wishlistAndNotificationService)
        {
            _wishlistAndNotificationService = wishlistAndNotificationService;
        }

        private int GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpGet("my-notifications")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetNotifications()
        {
            try
            {
                var loggedInUser = GetLoggedInUserId();
                var notifications = await _wishlistAndNotificationService.GetUserNotificationsAsync(loggedInUser);
                return Ok(new { success = true, message = "Notification fetched successfully.", data = notifications });
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
                return StatusCode(500, new { success = false, message = $"Error fetching notification: {ex.Message}" });
            }
        }

        [HttpPost("read")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> ReadNotification([FromQuery] int notificationId)
        {
            try
            {
                var loggedInUser = GetLoggedInUserId();
                await _wishlistAndNotificationService.MarkNotificationAsReadAsync(notificationId);
                return Ok(new { success = true, message = "Notification is mark as read." });
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
                return StatusCode(500, new { success = false, message = $"Error fetching notification: {ex.Message}" });
            }
        }

        [HttpGet("unread")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> UnReadNotification()
        {
            try
            {
                var loggedInUser = GetLoggedInUserId();
                var notificatios = await _wishlistAndNotificationService.GetUnreadNotificationCountAsync(loggedInUser);
                return Ok(new { success = true, message = "Unread Notification fetch Successfully.", data = notificatios });
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
                return StatusCode(500, new { success = false, message = $"Error fetching notification: {ex.Message}" });
            }
        }
    }
}