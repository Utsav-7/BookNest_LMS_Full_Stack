using LMS_Backend.LMS.Application.Interfaces;
using LMS_Backend.LMS.Application.Interfaces.Authentication;
using LMS_Backend.LMS.Application.Interfaces.BooksManagement;
using LMS_Backend.LMS.Application.Interfaces.BookTransactions;
using LMS_Backend.LMS.Application.Interfaces.GenreManagement;
using LMS_Backend.LMS.Application.Interfaces.PaginationServices;
using LMS_Backend.LMS.Application.Interfaces.SystemConfiguration;
using LMS_Backend.LMS.Application.Interfaces.UserManagement;
using LMS_Backend.LMS.Application.Interfaces.WishListAndNotification;
using LMS_Backend.LMS.Application.Services;
using LMS_Backend.LMS.Infrastructure.Helpers;
using LMS_Backend.LMS.Infrastructure.Repository;

namespace LMS_Backend.LMS.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IBorrowRequestRepository, BorrowRequestRepository>();
            services.AddScoped<IReturnRequestRepository, ReturnRequestRepository>();
            services.AddScoped<IPaginationRepository, PaginationRepository>();
            services.AddScoped<IWishlistAndNotificationRepository, WishlistAndNotificationRepository>();
            services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
            services.AddScoped<IDashboardStatRepository, DashboardStatRepository>();
            services.AddScoped<IStudentDashboardStatRepository, StudentDashboardStatRepository>();
            services.AddScoped<ISystemConfigRepository, SystemConfigRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IBorrowService, BorrowService>();
            services.AddScoped<IReturnService, ReturnService>();
            services.AddScoped<IPaginationService, PaginationService>();
            services.AddScoped<IWishlistAndNotificationService, WishlistAndNotificationService>();
            services.AddScoped<ITransactionHistoryService, TransactionService>();
            services.AddScoped<IDashboardStatService, DashboardStatService>();
            services.AddScoped<IStudentDashboardStatService, StudentDashboardStatService>();
            services.AddScoped<ISystemConfigService, SystemConfigService>();
            services.AddScoped<IEmailService, EmailHelper>();
            services.AddScoped<JwtTokenHelper>();

            return services;
        }
    }
}