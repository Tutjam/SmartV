using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartHome.Models;
using WebApplication14.Data;
using Microsoft.AspNetCore.Identity;


namespace SmartHome.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public RoomsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Rooms
        public async Task<IActionResult> Index(int? id)
        {
            /*if (id == null)
            {
                return View();
            }
            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return View(room);
            }
            var userId = _userManager.GetUserId(HttpContext.User);
            ICollection<Sensor> sensors = _context.Sensor.Where(x => (x.OwnerSensorId == userId)).ToList();
            ViewBag.sensors = sensors;
            ViewBag.room = room;
            return View(await _context.Room.Where(x => (x.OwnerId==userId)).ToListAsync());*/

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.Id == id);
            var lastIndex = _context.Room.Last().Id;
            if (room == null)
            {
                switch(id)
                {
                    case 1: return View(null);
                    case 0: return Redirect(lastIndex.ToString());
                    default: return Redirect("1");
                }
                /*if (id == 1)
                    return View(null);
                else
                    return Redirect("1");*/
            }

            return View(room);
        }

        // GET: Rooms/Settings
        public async Task<IActionResult> Settings()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            ICollection<Sensor> sensors = _context.Sensor.Where(x => (x.OwnerSensorId == userId)).ToList();
            ViewBag.sensors = sensors;
            return View(await _context.Room.Where(x => (x.OwnerId == userId)).ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,OwnerId")] Room room)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if (ModelState.IsValid)
            {
                room.OwnerId = userId;
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,OwnerId")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Settings));
            }
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Room.FindAsync(id);
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Settings));
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.Id == id);
        }
    }
}
