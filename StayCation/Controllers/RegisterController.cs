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
            return View();

            //_handler.ReadFromAnySqlTable();
        }


		public IActionResult Signup()
		{
            if(HttpContext.Request.Method == "GET")
            {
                return View();
            }
            else if(HttpContext.Request.Method == "POST")
            {
                string fullName = HttpContext.Request.Form["FullName"]!;
                string email = HttpContext.Request.Form["Email"]!;
                string password = HttpContext.Request.Form["Password"]!;
                var user = new User { FullName = fullName, Email = email, Password = password };

                _handler.WriteToTable("InsertUser", user); 
            }

             return RedirectToAction("Login");

            //_writer.WriteToFile("Users.txt", user);

        }





	}


}
