using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Domain.Entities
{
    public class Role : BaseEntity
    {
        [Key]
        public int RoleId { get; set; }

        [Required, MaxLength(100)]
        public string RoleName { get; set; }

        // Navigation properties
        public ICollection<User> Users { get; set; }
    }
}