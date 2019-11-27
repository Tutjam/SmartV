using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SmartHome.Models;

namespace SmartHome.Controllers
{
    public class PanelController : Controller
    {
        List<Room> rooms = new List<Room>();
        // GET: Panel
        public ActionResult Index()
        {
            return View("Views/Home/Panel.cshtml");
        }


        // GET: Panel/Create
        public ActionResult AddRoom()
        {
            return View("Views/Rooms/AddRoom.cshtml");
        }

        // POST: Panel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoom(Room room)
        {
            try
            {
                // TODO: Add insert logic here
                rooms.Add(room);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}