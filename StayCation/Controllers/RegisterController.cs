using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Hotel.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Signup()
        {
			return View();
		}


		



	}


}
