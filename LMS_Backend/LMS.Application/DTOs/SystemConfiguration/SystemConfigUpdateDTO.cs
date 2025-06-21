using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Application.DTOs.SystemConfiguration
{
    public class SystemConfigUpdateDTO
    {
        [Required(ErrorMessage = "Config ID is required.")]
        public int ConfigId { get; set; }

        [Required(ErrorMessage = "Configuration key is required.")]
        public string ConfigKey { get; set; }

        [Required(ErrorMessage = "Configuration value is required.")]
        public string ConfigValue { get; set; }

        public string? Description { get; set; }
    }
}