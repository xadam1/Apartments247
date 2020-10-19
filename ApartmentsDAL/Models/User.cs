using System.ComponentModel.DataAnnotations;

namespace ApartmentsDAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Username { get; set; }

        [EmailAddress]
        [MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(256)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
