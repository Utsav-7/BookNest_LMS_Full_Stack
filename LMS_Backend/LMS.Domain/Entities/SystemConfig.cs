using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Domain.Entities
{
    public class SystemConfig : BaseEntity
    {
        [Key]
        public int? ConfigId { get; set; }

        [Required]
        public string ConfigKey { get; set; }

        public string ConfigValue { get; set; }
        public string? Description { get; set; }
    }
}