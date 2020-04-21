using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeriLogDemo.Web.Models;

namespace SeriLogDemo.Web.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void Test()
        {
            _logger.LogInformation("You requested The index page.");
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 50)
                        throw new Exception("This is our demo Exception");
                    else
                        _logger.LogInformation("The value of i is {i}", i);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We caught this exception in the Test call.");
            }
        }

    }
}
