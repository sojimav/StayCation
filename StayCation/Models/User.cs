using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class User
    {
		public User(int id, string? fullName, string? email, string? password)
		{
			Id = id;
			FullName = fullName;
			Email = email;
			Password = password;
		}

		public int Id { get; set; } 

        [Required]
        public string? FullName { get;  set; }

        [Required]
        [EmailAddress]
        public string? Email { get;  set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }

}
