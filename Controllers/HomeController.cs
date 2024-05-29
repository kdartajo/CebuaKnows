using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CebuaKnows.Models;

namespace CebuaKnows.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (guestResponse.ImageName != null)
            {
                var fileName = Path.GetFileName(guestResponse.ImageName.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    guestResponse.ImageName.CopyTo(stream);
                }

                // Save the file name to the model (you might want to save the relative path instead)
                guestResponse.ImageFileName = fileName;
                Console.WriteLine($"Image saved at: {filePath}");
            }


            Repository.AddResponse(guestResponse);
            return View("Thanks", guestResponse);


        }

        public ViewResult Tour()
        {
            return View();
        }

        public ViewResult History()
        {
            return View();
        }

        public ViewResult Contacts()
        {
            return View();
        }
        public IActionResult Explore(string place)
        {
            var response = Repository.responses.FirstOrDefault(r => r.Place == place);
            if (response != null)
            {
                return View(response);
            }
            return NotFound();
        }
    }
}