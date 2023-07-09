using Final_Project_RentApp.Areas.Admin.ViewModels;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class QuaranteeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IQuaranteeService _quaranteeService;
        private readonly IWebHostEnvironment _env;

        public QuaranteeController(AppDbContext context, 
                                   IQuaranteeService quaranteeService,
                                   IWebHostEnvironment env)
        {
            _context = context;
            _quaranteeService = quaranteeService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            Quarantee quarantee = await _quaranteeService.GetQuaranteeAsync();

            return View(quarantee);
        }

        [HttpGet]
        public async Task<IActionResult> Detail()
        {
            Quarantee quarantee = await _context.Quarantees.Include(qi => qi.QuaranteeImages).FirstOrDefaultAsync();

            //Quarantee quarantee = await _quaranteeService.GetByIdAsync((int)id);

            if (quarantee == null) return NotFound();

            return View(quarantee);
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            Quarantee quarantee = await _quaranteeService.GetQuaranteeAsync();

            List<string> imagesNames = new();

            foreach (var image in quarantee.QuaranteeImages)
            {
                imagesNames.Add(image.Image);
            }

            QuaranteeEditVM model = new()
            {
                Id = quarantee.Id,
                Title = quarantee.Title,
                SubTitle = quarantee.SubTitle,
                Description = quarantee.Description,
                Image = imagesNames
			};


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(QuaranteeEditVM quarantee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                foreach (var photo in quarantee.Photos)
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

                List<QuaranteeImage> images = new();

                foreach (var photo in quarantee.Photos)
                {
                    string fileName = Guid.NewGuid().ToString() + "-" + photo.FileName;

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", fileName);

                    await FileHelper.SaveFileAsync(path, photo);

                    images.Add(new QuaranteeImage { Image = fileName });
                }

                Quarantee newQuarantee = new()
                {
                    Id = quarantee.Id,
                    QuaranteeImages = images,
                    Title = quarantee.Title,
                    SubTitle = quarantee.SubTitle,
                    Description = quarantee.Description,
                };

                _context.Quarantees.Update(newQuarantee);

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
