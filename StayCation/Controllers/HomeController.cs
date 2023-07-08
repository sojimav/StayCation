using Hotel.Interface;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileHandler _reader;
        private readonly IDataHandler _dataHandler;

        public HomeController(ILogger<HomeController> logger, IFileHandler reader, IDataHandler dataHandler)
		{
			_logger = logger;
			_reader = reader;
			_dataHandler = dataHandler;
		}

		public IActionResult Index()
        {
            List<Property> propertiesfromSQL = _dataHandler.ReadFromAnySqlTable("StayCationHomeProcedure", () => new Property("", "", "", "", "", ""));

            var mostpicks1 = propertiesfromSQL.Where(row => row.Group == "Most picks").ToList();
            var backyards1 = propertiesfromSQL.Where(row => row.Group == "Houses with beautiful Backyards").ToList();
            var largeLivingRooms1 = propertiesfromSQL.Where(row => row.Group == "Hotels with large living rooms").ToList();
            var kitchenSets1 = propertiesfromSQL.Where(row => row.Group == "Apartments with Kitchen set").ToList();

            Category sqlCategory = new Category(mostpicks1, backyards1, largeLivingRooms1, kitchenSets1);


            return View(sqlCategory);


            //var Allproperties = _reader.ReadFromPropertyFile("Database.txt");

            //var mostpicks = Allproperties.Where(row => row.Group == "Most picks").ToList();
            //var backyards = Allproperties.Where(row => row.Group == "Houses with beautiful Backyards").ToList();
            //var largeLivingRooms = Allproperties.Where(row => row.Group == "Hotels with large living rooms").ToList();
            //var KitchenSets = Allproperties.Where(row => row.Group == "Apartments with Kitchen set").ToList();

            ////Category category =  new Category(mostpicks, backyards, largeLivingRooms, KitchenSets);

            //         ViewData["mostpicks"] = mostpicks;
            //         ViewData["backyards"] = backyards;
            //         ViewData["livingrooms"] = largeLivingRooms;
            //         ViewData["kitchensets"] = KitchenSets;

            //         var first_mostpicks = mostpicks.FirstOrDefault();
            //         var first_backyard = backyards.FirstOrDefault();
            //         ViewData["first_mostpicks"] = first_mostpicks;
            //         ViewData["first_backyards"] = first_backyard;




            /*---------------------------------------------------------------*/
            /*---------------Reading From the Sql Database-------------------*/
            /*---------------------------------------------------------------*/
            //var prop = new Property();


        }



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}