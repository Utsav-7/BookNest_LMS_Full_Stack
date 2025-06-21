namespace LMS_Backend.LMS.Application.DTOs.WishListAndNotification
{
    public class WishlistResponseDTO
    {
        public int WishListId { get; set; }
        public string? CoverImageUrl { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}