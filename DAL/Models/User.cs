using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace DAL.Models
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(64)]
        public string Username { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(128)]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public User(int id, string username, string password, string email, bool isAdmin)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            IsAdmin = isAdmin;
        }

        public User(SqlDataReader reader) : this(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4) != 0) { }
    }
}
