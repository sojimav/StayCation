﻿using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
	public class LoginUser
	{

		[Required]
		[EmailAddress]
		public string? Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
	}
}
