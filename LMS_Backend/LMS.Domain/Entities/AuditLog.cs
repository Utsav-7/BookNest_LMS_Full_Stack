using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Domain.Entities
{
    public class AuditLog
    {
        [Key]
        public int LogId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public string Entity { get; set; }
        public int EntityId { get; set; }
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User User { get; set; }
    }
}