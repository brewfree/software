using System;
using Microsoft.AspNetCore.Mvc;

namespace BrewFree.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ErrorTest()
        {
            throw new Exception("Test");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
