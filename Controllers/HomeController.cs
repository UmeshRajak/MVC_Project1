using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Project1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project1.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [ViewData]
        public string  Title { get; set; }
        public ViewResult Index()
        {
            Title = "Home";
            return View();

        }

        public ViewResult AboutUs()
        {
            Title = "About";
            dynamic data = new ExpandoObject();
            data.id = 1;
            data.name = "umesh";
            ViewBag.some = data;

            ViewBag.N = "Umesh";



            return View();
        }
        public ViewResult ContectUs()
        {
            Title = "ContectUs";
            //ViewBag.some1 = new { id = 5, name = "xyz" };
            ViewBag.some = new BookModel() { id = 1, Author = "umesh" };
            ViewData["book"] = new BookModel { id = 1, Author = "ram" };
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ViewResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
