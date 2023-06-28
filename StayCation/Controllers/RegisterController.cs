using Hotel.Interface;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Hotel.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IFileHandler _writer;

        public RegisterController(IFileHandler writer)
        {
            _writer = writer;
        }


        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Signup()
        {
			return View();
		}



        [HttpPost]
		public IActionResult Signup( User user)
		{
    
            _writer.WriteToFile("Users.txt", user);

            return RedirectToAction("Login");
		}





	}


}
