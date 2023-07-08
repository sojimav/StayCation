using Hotel.Helpers;
using Hotel.Interface;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Hotel.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IFileHandler _writer;
        private readonly IDataHandler _handler;

        public RegisterController(IFileHandler writer, IDataHandler handler)
        {
            _writer = writer;
            _handler = handler;
        }


        public IActionResult Login()
        {                     
            if (HttpContext.Request.Method == "POST")
            {          
                List<User> propertiesfromSQL = _handler.ReadFromAnySqlTable("FetchUserDetails", () => new User(0, "", "", ""));

				string email = HttpContext.Request.Form["Email"]!;
				string password = HttpContext.Request.Form["Password"]!;

				var valid = propertiesfromSQL.FirstOrDefault(row => row.Password.Trim() == password.Trim() && row.Email.Trim() == email.Trim());
                if (valid != null)
                {
					return RedirectToAction("Index", "Home");
				}			
			}

			     return View();

			//_handler.ReadFromAnySqlTable();
		}


		public IActionResult Signup()
		{                                
             if(HttpContext.Request.Method == "POST")
            {
                string fullName = HttpContext.Request.Form["FullName"]!;
                string email = HttpContext.Request.Form["Email"]!;
                string password = HttpContext.Request.Form["Password"]!;
                var user = new User (id:0, fullName, email, password);
                _handler.WriteToTable("InsertUser", user);

				return RedirectToAction("Login");

			}
			    return View();
			//_writer.WriteToFile("Users.txt", user);

		}


	}


}
