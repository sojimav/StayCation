using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
			var Allproperties = ReadFromPropertyFile("Database.txt");

			var mostpicks = Allproperties.Where(row => row.Group == "Most picks").ToList();
			var backyards = Allproperties.Where(row => row.Group == "Houses with beautiful Backyards").ToList();
			var largeLivingRooms = Allproperties.Where(row => row.Group == "Hotels with large living rooms").ToList();
			var KitchenSets = Allproperties.Where(row => row.Group == "Apartments with Kitchen set").ToList();

			Category category =  new Category(mostpicks, backyards, largeLivingRooms, KitchenSets);

			ViewData["mostpicks"] = mostpicks;
			ViewData["backyards"] = backyards;
			ViewData["livingrooms"] = largeLivingRooms;
			ViewData["kitchensets"] = KitchenSets;

			var first_mostpicks = mostpicks.FirstOrDefault();
			var first_backyard = backyards.FirstOrDefault();
            ViewData["first_mostpicks"] = first_mostpicks;
			ViewData["first_backyards"] = first_backyard;

            return View();
        }



		public static List<Property> ReadFromPropertyFile(string filepath)
		{
			var PropertyFile = new List<Property>();
			using (StreamReader reader = new StreamReader(filepath))
			{
				string? read;
				while ((read = reader.ReadLine()) != null)
				{
					if (!string.IsNullOrEmpty(read))
					{
						string[] lines = read.Split("|");

						if (lines.Length >= 6)
						{
							string group = lines[1].Trim();
							string image = lines[2].Trim();
							string price = lines[3].Trim();
							string NameofProp = lines[4].Trim();
							string Location = lines[5].Trim();
							string Popularity = lines[6].Trim();
							Property property = new Property(group, image, price, NameofProp, Location, Popularity);
							PropertyFile.Add(property);
						}
					}
				}
			}

			return PropertyFile;
		}














		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}