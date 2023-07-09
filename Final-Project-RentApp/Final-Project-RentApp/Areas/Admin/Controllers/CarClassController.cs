using Final_Project_RentApp.Areas.Admin.ViewModels;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CarClassController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICarClassService _carClassService;
        private readonly IWebHostEnvironment _env;


        public CarClassController(AppDbContext context,
                                  ICarClassService carClassService,
                                  IWebHostEnvironment env)
        {
            _context = context;
            _carClassService = carClassService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CarClass> carClasses = await _carClassService.GetAllAsync();

            return View(carClasses);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            CarClass carClass = await _carClassService.GetByIdAsync((int)id);

            if (carClass == null) return NotFound();

            return View(carClass);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarClassCreateVM carClass)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                foreach (var photo in carClass.Photos)
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

                decimal convertedPrice = decimal.Parse(carClass.StartPrice.Replace(".",","));

                foreach (var photo in carClass.Photos)
                {
                    string fileName = Guid.NewGuid().ToString() + "-" + photo.FileName;

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", fileName);

                    await FileHelper.SaveFileAsync(path, photo);

                    CarClass newCarClass = new()
                    {
                        Image = fileName,
                        StartPrice = convertedPrice,
                        Name = carClass.Name,
                    };

                    await _context.CarClasses.AddAsync(newCarClass);
                }

                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));

            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null) return BadRequest();

                CarClass carClass = await _carClassService.GetByIdAsync((int)id);

                if (carClass is null) return NotFound();

                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", carClass.Image);

                FileHelper.DeleteFile(path);

                _context.CarClasses.Remove(carClass);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            CarClass carClass = await _carClassService.GetByIdAsync((int)id);

            if (carClass is null) return NotFound();

            CarClassEditVM model = new()
            {
                Id = carClass.Id,
                Name = carClass.Name,
                StartPrice = carClass.StartPrice.ToString(),
                Image = carClass.Image
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CarClassEditVM carClass)
        {
            try
            {

                if (id == null) return BadRequest();

                CarClass dbCarClass = await _carClassService.GetByIdAsync((int)id);

                if (carClass is null) return NotFound();

                if (!ModelState.IsValid)
                {
                    carClass.Image = dbCarClass.Image;

                    return View(carClass);
                }
                decimal convertedPrice = decimal.Parse(carClass.StartPrice.Replace(".", ","));

                CarClassEditVM model = new()
                {
                    Id = carClass.Id,
                    Name = carClass.Name,
                    Image = carClass.Image,
                    StartPrice=convertedPrice.ToString(),
                    
                };

                if (carClass.Photo != null)
                {
                    if (!carClass.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "File type must be image");
                        return View(dbCarClass);
                    }

                    if (!carClass.Photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photo", "Image size must be max 200kb");
                        return View(dbCarClass);
                    }

                    string oldPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", dbCarClass.Image);

                    FileHelper.DeleteFile(oldPath);

                    string fileName = Guid.NewGuid().ToString() + "-" + carClass.Photo.FileName;

                    string newPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", fileName);

                    await FileHelper.SaveFileAsync(newPath, carClass.Photo);

                    dbCarClass.Image = fileName;
                }
                else
                {
                    CarClass newCarClass = new()
                    {
                        Image = dbCarClass.Image
                    };
                }

                dbCarClass.Name = carClass.Name;
                dbCarClass.StartPrice = convertedPrice;
                //dbCarClass.StartPrice = carClass.StartPrice;

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
