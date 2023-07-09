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

        [Required(ErrorMessage = "full name is Required!")]
        [RegularExpression(@"^[A-Z][a-z]{2,29}( [A-Z][a-z]{2,29})+$", ErrorMessage = "Enter a Valid Name Format! e.g Ajibade Victor")]
        public string? FullName { get;  set; }

        [Required]
        [EmailAddress]
        //[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format!")]
        public string? Email { get;  set; }

        [Required]
        [RegularExpression("^(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$", ErrorMessage = "Password must have a special charater and a digt! e.g @adesoji1")]
        public string? Password { get; set; }
    }

}
