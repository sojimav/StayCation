using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class User
    {
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
