using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;

namespace EFCoreAspNetWebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangePubDate (int id, [FromServices] IChangePubDateService service)
        {
            var dto = service.GetOriginal(id);
            return View(dto); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePubDate(ChangePubDateDto dto, [FromServices] IChangePubDateService service)
        {
            service.UpdateBook(dto);
            return View("BookUpdated", "Successfully changed publication date");
        }
    }
}