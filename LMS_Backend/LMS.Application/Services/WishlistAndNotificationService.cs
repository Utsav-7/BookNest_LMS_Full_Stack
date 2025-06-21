using LMS_Backend.LMS.Application.DTOs.WishListAndNotification;
using LMS_Backend.LMS.Application.Interfaces.WishListAndNotification;

namespace LMS_Backend.LMS.Application.Services
{
    public class WishlistAndNotificationService : IWishlistAndNotificationService
    {
        private readonly IWishlistAndNotificationRepository _wishlistAndNotificationRepository;

        public WishlistAndNotificationService(IWishlistAndNotificationRepository wishlistAndNotificationRepository)
        {
            _wishlistAndNotificationRepository = wishlistAndNotificationRepository;
        }

        public async Task<bool> AddToWishlistAsync(int userId, int bookId)
        {
            return await _wishlistAndNotificationRepository.AddToWishlistQuery(userId, bookId);
        }

        public async Task<int> GetUnreadNotificationCountAsync(int userId)
        {
            return await _wishlistAndNotificationRepository.GetUnreadNotificationCountQuery(userId);
        }

        public async Task<IEnumerable<NotificationDTO>> GetUserNotificationsAsync(int userId)
        {
            return await _wishlistAndNotificationRepository.GetUserNotificationsQuery(userId);
        }

        public async Task<IEnumerable<WishlistResponseDTO>> GetUserWishlistAsync(int userId)
        {
            return await _wishlistAndNotificationRepository.GetUserWishlistQuery(userId);
        }

        public async Task MarkNotificationAsReadAsync(int notificationId)
        {
            await _wishlistAndNotificationRepository.MarkNotificationAsReadQuery(notificationId);
        }

        public async Task ProcessReturnedBookNotificationsAsync(int bookId)
        {
            await _wishlistAndNotificationRepository.ProcessReturnedBookNotificationsQuery(bookId);
        }

        public async Task<bool> RemoveFromWishlistAsync(int wishlistId)
        {
            return await _wishlistAndNotificationRepository.RemoveFromWishlistQuery(wishlistId);
        }
    }
}