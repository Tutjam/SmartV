using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View();
            //return RedirectToAction("Index", "Rooms");
            return Redirect("Rooms/Index/1");
        }

        public IActionResult Login()
        {
            return View("Areas/Identity/Pages/Account/Login");
        }

        public IActionResult Panel()
        {
            return RedirectToAction("Index","Rooms");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
