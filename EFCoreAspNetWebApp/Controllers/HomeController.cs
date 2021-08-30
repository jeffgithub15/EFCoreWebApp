using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFCoreAspNetWebApp.Models;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using System.Data.Common;
using ServiceLayer.Interfaces;

namespace EFCoreAspNetWebApp.Controllers
{
    public class HomeController : Controller
    {
        //private IDemo _demo;
        //public HomeController(IDemo demo)
        //{
        //    this._demo = demo;
        //}



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
    }
}                                                                                                                                                   



