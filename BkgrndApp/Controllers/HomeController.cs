using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BkgrndApp.Models;
using Microsoft.Extensions.Caching.Memory;

namespace BkgrndApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache memoryCache;
        public HomeController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public string Message { get; set; }
        public IActionResult Index()
        {
            
            return View();
        }
        public void OnGet()

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
