using Microsoft.AspNetCore.Mvc;
using MyController.Models;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;

namespace MyController.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /////////////////////////////////////////////////

        //Action
        public IActionResult Index(int score)
        {
            string result = "";


            if (score >= 90 && score <= 100)
            {
                result = "纔单";
            }
            else if (score >= 80)
            {
                result = "ヒ单";
            }
            else if (score >= 70)
            {
                result = "单";
            }
            else if (score >= 60)
            {
                result = "单";
            }
            else
                result = "单";

            ViewData["Level"] = result;

            return View();
        }

        //Action
        public IActionResult Privacy()
        {
            return View();
        }

        /////////////////////////////////////////////////


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
