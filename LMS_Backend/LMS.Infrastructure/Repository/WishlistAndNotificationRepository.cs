using LMS_Backend.LMS.Application.DTOs.WishListAndNotification;
using LMS_Backend.LMS.Application.Interfaces;
using LMS_Backend.LMS.Application.Interfaces.WishListAndNotification;
using LMS_Backend.LMS.Common.Exceptions;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LMS_Backend.LMS.Infrastructure.Repository
{
    public class WishlistAndNotificationRepository : GenericRepository<WishList>, IWishlistAndNotificationRepository
    {
        private readonly IEmailService _emailService;
        public WishlistAndNotificationRepository(ApplicationDBContext context, IEmailService emailService): base(context)
        {
            _emailService = emailService;
        }

        public async Task<bool> AddToWishlistQuery(int userId, int bookId)
        {
            var existingRecords = await _context.WishLists.FirstOrDefaultAsync(s => s.UserId == userId && s.BookId == bookId && !s.IsAvailable && s.DeletedAt == null);

            if (existingRecords != null)
                throw new AlreadyExistsException<string>($"Book is already in Wishlist.");

            var wishlist = new WishList
            {
                UserId = userId,
                BookId = bookId,
                CreatedAt = DateTime.UtcNow
            };

            await _context.WishLists.AddAsync(wishlist);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> GetUnreadNotificationCountQuery(int userId)
        {
            return await _context.Notifications.CountAsync(n => n.UserId == userId && !n.IsRead && n.Type == Domain.Enums.NotificationType.Application);
        }

        public async Task<IEnumerable<NotificationDTO>> GetUserNotificationsQuery(int userId)
        {
            var notificationList = await _context.Notifications
                .Where(s => s.UserId == userId && s.Type == Domain.Enums.NotificationType.Application)
                .Select(s => new NotificationDTO { 
                    NotificationId = s.NotificationId,  
                    Message = s.Message,
                    UserId = s.UserId,
                    IsRead = s.IsRead
                })
                .ToListAsync();

            return notificationList;
        }

        public async Task<IEnumerable<WishlistResponseDTO>> GetUserWishlistQuery(int userId)
        {
            var wishList = await _context.WishLists.Include(s => s.Book)
                                                   .Where(s => s.UserId == userId && !s.IsAvailable && s.DeletedAt == null)
                                                   .Select(s => new WishlistResponseDTO
                                                   {    
                                                       WishListId = s.WishListId,
                                                       CoverImageUrl = s.Book.CoverImageUrl,
                                                       Title = s.Book.Title,
                                                       Author = s.Book.Author,
                                                   }).ToListAsync();

            return wishList;
        }

        public async Task MarkNotificationAsReadQuery(int notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);

            if (notification == null)
                throw new DataNotFoundException<string>($"No Any Notification Find with {notificationId} id.");

            notification.IsRead = true;

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
        }

        public async Task ProcessReturnedBookNotificationsQuery(int bookId)
        {
            var wishlistEntries = await _context.WishLists
                            .Include(w => w.Book)
                            .Include(w => w.User)
                            .Where(w => w.BookId == bookId && !w.Notified)
                            .ToListAsync();

            var book = await _context.Books.FindAsync(bookId);
            if (book == null || book.AvailableCopies <= 0) return;

            foreach (var entry in wishlistEntries)
            {
                entry.Notified = true;
                entry.IsAvailable = true;
                _context.WishLists.Update(entry);

                    
                var emailNotification = new Notification
                {
                    UserId = entry.UserId,
                    Message = $"The book '{entry.Book.Title}' you wished for is now available!",
                    Type = Domain.Enums.NotificationType.Email,
                    IsRead = false,
                    CreatedAt = DateTime.UtcNow
                };

                var appNotification = new Notification
                {
                    UserId = entry.UserId,
                    Message = $"The book '{entry.Book.Title}' you wished for is now available!",
                    Type = Domain.Enums.NotificationType.Application,
                    IsRead = false,
                    CreatedAt = DateTime.UtcNow
                };

                await _context.Notifications.AddAsync(appNotification);
                await _context.Notifications.AddAsync(emailNotification);

                await _emailService.SendWishlistAvailableEmailAsync(
                    entry.User.Email,
                    $"{entry.User.FirstName} {entry.User.LastName}",
                    entry.Book.Title,
                    book.AvailableCopies
                );
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoveFromWishlistQuery(int wishlistId)
        {
            var wishlist = await _context.WishLists.FindAsync(wishlistId);
            if (wishlist == null) return false;

            wishlist.DeletedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}