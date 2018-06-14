using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kloud.web.Models;
using Microsoft.Extensions.Options;

namespace kloud.web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Application Settings
        /// </summary>
        public readonly AppSettings _appSettings;

        /// <summary>
        /// Home constructor
        /// </summary>
        public HomeController(AppSettings appsettings)
        {
            _appSettings = appsettings;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["ApplicationName"] = _appSettings.ApplicationName;
            ViewData["Environment"] = _appSettings.Environment;
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["ContactInfo"] = _appSettings.ContactInfo;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
