using LMS_Backend.LMS.Application.DTOs.WishListAndNotification;

namespace LMS_Backend.LMS.Application.Interfaces.WishListAndNotification
{
    public interface IWishlistAndNotificationService
    {
        Task<bool> AddToWishlistAsync(int userId, int bookId);
        Task<bool> RemoveFromWishlistAsync(int wishlistId);
        Task<IEnumerable<WishlistResponseDTO>> GetUserWishlistAsync(int userId);

        // Notification Methods
        Task<IEnumerable<NotificationDTO>> GetUserNotificationsAsync(int userId);
        Task MarkNotificationAsReadAsync(int notificationId);
        Task<int> GetUnreadNotificationCountAsync(int userId);

        // Combined Feature Methods
        Task ProcessReturnedBookNotificationsAsync(int bookId);
    }
}