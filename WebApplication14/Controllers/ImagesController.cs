using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication14.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartHome.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHostingEnvironment he;

        public ImagesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IHostingEnvironment e)
        {
            _context = context;
            _userManager = userManager;
            he = e;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {   
            var userId = _userManager.GetUserId(HttpContext.User);
            ICollection<Room> rooms = _context.Room.Where(x => (x.OwnerId == userId)).ToList();
            ViewBag.rooms = rooms;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ImageId,RoomId,OwnerImageId")] Image image ,IFormFile file)
        {

            if (file == null)
            {
                ViewBag.String = "Brak wybranego pliku!";
                return View("~/Views/Images/Erroe.cshtml");
            }
            if ((file.Length / 1048576.0) > 5) //rozmiar wiekszy niż 5 mb
            {
                ViewBag.String = "Plik za duży!";
                return View("~/Views/Images/Erroe.cshtml");
            }
            string extension = Path.GetExtension(file.FileName);
            if ((extension == ".jpg") || (extension == ".png"))
            {

                var filename = Path.Combine(he.WebRootPath, Path.GetFileName(file.FileName));

                using (var stream = new FileStream(filename, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var userId = _userManager.GetUserId(HttpContext.User);
                if (ModelState.IsValid)
                {
                    
                    image.OwnerImageId = userId;
                    _context.Add(image);

                    await _context.SaveChangesAsync();
                   
                    return RedirectToAction("Index","Rooms");
                }

                return View(image);

            }
            ViewBag.String = "Błędny typ pliku!";
            return View("~/Views/Images/Erroe.cshtml");
        }
    }
}
