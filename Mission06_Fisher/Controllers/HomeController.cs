using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Fisher.Models;

namespace Mission06_Fisher.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Static page describing Joel
        public IActionResult GetToKnowJoel()
        {
            return View();
        }
    }
