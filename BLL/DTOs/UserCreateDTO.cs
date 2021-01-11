using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
