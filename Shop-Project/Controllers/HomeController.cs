using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop_Project.Data;
using Shop_Project.Models;

namespace Shop_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Shop_ProjectContext _context;

        public HomeController(ILogger<HomeController> logger, Shop_ProjectContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult HomePage()
        {

            List<Game> games = new List<Game>();
            foreach (Game g in _context.Game)
            {
                games.Add(g);
            }
            List<Models.ConsoleVersion> consoles = new List<Models.ConsoleVersion>();
            foreach(Models.ConsoleVersion c in _context.ConsoleVersion)
            {
                consoles.Add(c);
            }
            ProductConsole productConsole = new ProductConsole
            {
                Games = games,
                Consoles = consoles
            };
            return View(productConsole);
        }



        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            /* if (HttpContext.Session.GetString("username") == null) {
               return RedirectToAction("Login", "Users");
           }*/
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
