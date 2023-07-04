using Final_Project_RentApp.Areas.Admin.ViewModels;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PremiumRentalController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPremiumRentalService _premiumRentalService;
        private readonly IWebHostEnvironment _env;

        public PremiumRentalController(AppDbContext context,
                                       IPremiumRentalService premiumRentalService,
                                       IWebHostEnvironment env)
        {
            _context = context;
            _premiumRentalService = premiumRentalService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            PremiumRental premiumRental = await _premiumRentalService.GetPremiumRentalAsync();

            return View(premiumRental);
        }

        [HttpGet]
        public async Task<IActionResult> Detail()
        {
            PremiumRental premiumRental = await _context.PremiumRentals.Include(pri => pri.PremiumRentalImages).FirstOrDefaultAsync();

            //Quarantee quarantee = await _quaranteeService.GetByIdAsync((int)id);

            if (premiumRental == null) return NotFound();

            return View(premiumRental);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            PremiumRental premiumRental = await _premiumRentalService.GetPremiumRentalAsync();

            List<string> imagesNames = new();

            foreach (var image in premiumRental.PremiumRentalImages)
            {
                imagesNames.Add(image.Image);
            }

            PremiumRentalEditVM model = new()
            {
                Id = premiumRental.Id,
                Title = premiumRental.Title,
                SubTitle = premiumRental.SubTitle,
                Description = premiumRental.Description,
                ExperienceTitle = premiumRental.ExperienceTitle,
                ExperienceCount = premiumRental.ExperienceCount,
                ClientNumber = premiumRental.ClientNumber,
                Clients = premiumRental.Clients,
                Image = imagesNames
            };


            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PremiumRentalEditVM premiumRental)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                foreach (var photo in premiumRental.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "File type must be image");
                        return View();
                    }

                    if (!photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photo", "Image size must be max 200kb");
                        return View();
                    }
                }

                List<PremiumRentalImage> images = new();

                foreach (var photo in premiumRental.Photos)
                {
                    string fileName = Guid.NewGuid().ToString() + "-" + photo.FileName;

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", fileName);

                    await FileHelper.SaveFileAsync(path, photo);

                    images.Add(new PremiumRentalImage { Image = fileName });
                }

                PremiumRental newPremiumRental = new()
                {
                    Id = premiumRental.Id,
                    PremiumRentalImages = images,
                    Title = premiumRental.Title,
                    SubTitle = premiumRental.SubTitle,
                    Description = premiumRental.Description,
                    Clients = premiumRental.Clients,
                    ClientNumber = premiumRental.ClientNumber,
                    ExperienceCount = premiumRental.ExperienceCount,
                    ExperienceTitle = premiumRental.ExperienceTitle
                };

                _context.PremiumRentals.Update(newPremiumRental);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            catch (Exception)
            {
                throw;
            }
        }


    }
}
