using LMS_Backend.LMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.LMS.Infrastructure.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {}

        public DbSet<Role> Roles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<BorrowRequest> BorrowRequests { get; set; }
        public DbSet<ReturnRequest> ReturnRequests { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---------- GLOBAL FILTERS FOR SOFT DELETE ----------
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Book>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<BookReview>().HasQueryFilter(r => !r.IsDeleted);

            // ---------- UNIQUE CONSTRAINTS ----------
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // ---------- RELATIONSHIPS ----------
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId);

            modelBuilder.Entity<WishList>()
                .HasOne(w => w.User)
                .WithMany(u => u.WishLists)
                .HasForeignKey(w => w.UserId);

            modelBuilder.Entity<WishList>()
                .HasOne(w => w.Book)
                .WithMany(b => b.WishLists)
                .HasForeignKey(w => w.BookId);

            modelBuilder.Entity<BorrowRequest>()
                .HasOne(b => b.User)
                .WithMany(u => u.BorrowRequests)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<BorrowRequest>()
                .HasOne(b => b.Book)
                .WithMany(bk => bk.BorrowRequests)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<ReturnRequest>()
                .HasOne(r => r.BorrowRequest)
                .WithOne(b => b.ReturnRequest)
                .HasForeignKey<ReturnRequest>(r => r.BorrowRequestId);

            modelBuilder.Entity<BookReview>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<BookReview>()
                .HasOne(r => r.Book)
                .WithMany(b => b.BookReviews)
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<AuditLog>()
                .HasOne(a => a.User) 
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- SEED DATA ----------
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Administrator", CreatedAt = DateTime.UtcNow, CreatedBy = 0 },
                new Role { RoleId = 2, RoleName = "Librarian", CreatedAt = DateTime.UtcNow, CreatedBy = 0 },
                new Role { RoleId = 3, RoleName = "Student", CreatedAt = DateTime.UtcNow, CreatedBy = 0 }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, GenreName = "Science Fiction", Description = "Futuristic and scientific concepts", CreatedAt = DateTime.UtcNow },
                new Genre { GenreId = 2, GenreName = "Mystery", Description = "Crime and secret unraveling", CreatedAt = DateTime.UtcNow },
                new Genre { GenreId = 3, GenreName = "Biography", Description = "Life stories of individuals", CreatedAt = DateTime.UtcNow },
                new Genre { GenreId = 4, GenreName = "Self Help", Description = "Personal development books", CreatedAt = DateTime.UtcNow },
                new Genre { GenreId = 5, GenreName = "Fantasy", Description = "Magical and supernatural worlds", CreatedAt = DateTime.UtcNow },
                new Genre { GenreId = 6, GenreName = "Romance", Description = "Love stories and relationships", CreatedAt = DateTime.UtcNow },
                new Genre { GenreId = 7, GenreName = "Horror", Description = "Scary and thrilling stories", CreatedAt = DateTime.UtcNow },
                new Genre { GenreId = 8, GenreName = "History", Description = "Historical events and narratives", CreatedAt = DateTime.UtcNow },
                new Genre { GenreId = 9, GenreName = "Thriller", Description = "Fast-paced and suspenseful stories", CreatedAt = DateTime.UtcNow },
                new Genre { GenreId = 10, GenreName = "Children's", Description = "Books for kids and young readers", CreatedAt = DateTime.UtcNow },
                new Genre { GenreId = 11, GenreName = "Others", Description = "Covers books that do not fit into any predefined genre categories.", CreatedAt = DateTime.UtcNow }
            );


            modelBuilder.Entity<SystemConfig>().HasData(
                new SystemConfig
                {
                    ConfigId = 1,
                    ConfigKey = "MaxBorrowPeriod",
                    ConfigValue = "14",
                    Description = "Maximum number of days a book can be borrowed",
                    CreatedAt = DateTime.UtcNow
                },
                new SystemConfig
                {
                    ConfigId = 2,
                    ConfigKey = "MaxBorrowLimit",
                    ConfigValue = "3",
                    Description = "Maximum number of books a student can have borrowed at the same time",
                    CreatedAt = DateTime.UtcNow
                },
                new SystemConfig
                {
                    ConfigId = 3,
                    ConfigKey = "PenaltyPerDay",
                    ConfigValue = "20",
                    Description = "Penalty per day for late return",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}