using Final_Project_RentApp.Areas.Admin.ViewModels;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Formats.Asn1;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICarService _carService;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly ICarClassService _carClassService;

        public CarController(AppDbContext context,
                             ICarService carService,
                             IWebHostEnvironment env,
                             ICategoryService categoryService,
                             ITagService tagService, ICarClassService carClassService)
        {
            _context = context;
            _carService = carService;
            _env = env;
            _categoryService = categoryService;
            _tagService = tagService;
            _carClassService = carClassService;

        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Car> cars = await _carService.GetAllAsync();

            List<CarIndexVM> model = new List<CarIndexVM>();

            foreach (var car in cars)
            {
                CarIndexVM mappedData = new CarIndexVM()
                {
                    Id = car.Id,
                    Name = car.Name,
                    Image = car.CarImages.FirstOrDefault(ci => ci.IsMain).Image,
                    Price = car.Price
                };

                model.Add(mappedData);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Car car = await _carService.GetByIdAsync((int)id);

            if (car is null) return NotFound();

            List<string> images = new List<string>();

            foreach (var image in car.CarImages)
            {
                images.Add(image.Image);
            }

            List<string> tags = new List<string>();

            foreach (var tag in car.CarTags.Select(pt => pt.Tag))
            {
                tags.Add(tag.Name);
            }


            List<string> categories = new List<string>();

            foreach (var category in car.CarCategories.Select(ct => ct.Category))
            {
                categories.Add(category.Name);
            }

            CarAdminDetailVM model = new CarAdminDetailVM()
            {
                Name = car.Name,
                Price = car.Price,
                Description = car.Description,
                ShortDescription = car.ShortDescription,
                Extra = car.Extra,
                Images = images,
                Categories = categories,
                Tags = tags,
                CarClass = car.CarClass,

                //CreatedAt = product.CreatedAt,
                //UpdatedAt = product.UpdatedAt
            };

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await GetCategoriesAsync();

            ViewBag.tags = await GetTagsAsync();

            ViewBag.carClass = await GetCarClassAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarCreateVM model)
        {
            try
            {
                IEnumerable<Car> products = await _carService.GetAllAsync();

                ViewBag.categories = await GetCategoriesAsync();

                ViewBag.tags = await GetTagsAsync();


                if (!ModelState.IsValid)
                {
                    return View(model);
                }


                //foreach (var photo in model.Photos)
                //{

                //    if (!photo.CheckFileType("image/"))
                //    {
                //        ModelState.AddModelError("Photos", "File type must be image");
                //        return View();

                //    }

                //    if (!photo.CheckFileSize(200))
                //    {
                //        ModelState.AddModelError("Photos", "Image size must be max 200kb");
                //        return View();
                //    }

                //}



                List<CarTag> tags = new();

                foreach (var tagId in model.CarTags)
                {

                     CarTag tag = new()
                    {
                        TagId = tagId
                    };

                    tags.Add(tag);
                }


                List<CarCategory> categories = new();

                foreach (var categoryId in model.CarCategories)
                {

                    CarCategory carCategory = new()
                    {
                        CategoryId = categoryId
                    };

                    categories.Add(carCategory);
                }


                List<CarImage> carImages = new();


                foreach (var photo in model.Photos)
                {
                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;


                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", fileName);

                    await FileHelper.SaveFileAsync(path, photo);


                    CarImage carImage = new()
                    {
                        Image = fileName
                    };

                    carImages.Add(carImage);

                }

                carImages.FirstOrDefault().IsMain = true;
                //carImages.Skip(1).FirstOrDefault().IsPreview = true;

                decimal convertedPrice = decimal.Parse(model.Price.Replace(".", ","));

                Car newCar = new()
                {
                    Name = model.Name,
                    Price = convertedPrice,
                    ShortDescription = model.ShortDescription,
                    Description = model.Description,
                    Extra = model.Extra,
                    CarClassId = model.CarClassId,
                    CarCategories = categories,
                    CarTags = tags,
                    CarImages = carImages
                };


                await _context.CarImages.AddRangeAsync(carImages);

                await _context.Cars.AddAsync(newCar);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            catch (Exception)
            {
                throw;
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id is null) return BadRequest();

        //    Car car = await _carService.GetByIdAsync((int)id);

        //    if (car is null) return NotFound();

        //    foreach (var image in car.CarImages)
        //    {
        //        string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", image.Image);

        //        FileHelper.DeleteFile(path);
        //    }

        //    _context.Cars.Remove(car);

        //    _context.SaveChangesAsync();

        //    return Ok();
        //}

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null) return BadRequest();

                Car car = await _carService.GetByIdAsync((int)id);

                if (car is null) return NotFound();

                foreach (var image in car.CarImages)
                {
                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", image.Image);

                    FileHelper.DeleteFile(path);
                }

                _context.Cars.Remove(car);

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

            Car dbCar = await _carService.GetByIdAsync((int)id);

            if (dbCar is null) return NotFound();


            ViewBag.categories = await GetCategoriesAsync();

            ViewBag.tags = await GetTagsAsync();

            ViewBag.carClass = await GetCarClassAsync();


            return View(new CarEditVM
            {
                Id = dbCar.Id,
                Name = dbCar.Name,
                Description = dbCar.Description,
                ShortDescription = dbCar.ShortDescription,
                Extra = dbCar.Extra,
                Price = dbCar.Price.ToString("0.#####").Replace(",", "."),
                CarCategoriesId = dbCar.CarCategories.Select(c => c.CategoryId).ToList(),
                CarTagsId = dbCar.CarTags.Select(c => c.TagId).ToList(),
                CarClassId = dbCar.CarClassId,
                Images = dbCar.CarImages,

            });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CarEditVM updatedCar)
        {

            if (!ModelState.IsValid) return View(updatedCar);

            Car dbCar = await _carService.GetByIdAsync((int)id);

            if (dbCar is null) return NotFound();

            List<CarTag> tags = new();

            foreach (var tagId in updatedCar.CarTagsId)
            {

                CarTag tag = new()
                {
                    TagId = tagId
                };

                tags.Add(tag);
            }

            List<CarCategory> categories = new();

            foreach (var categoryId in updatedCar.CarCategoriesId)
            {

                CarCategory carCategory = new()
                {
                    CategoryId = categoryId
                };

                categories.Add(carCategory);
            }


            if (updatedCar.Photos != null)
            {

                foreach (var photo in updatedCar.Photos)
                {

                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "File type must be image");
                        return View(dbCar);
                    }

                    if (!photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photo", "Image size must be max 200kb");
                        return View(dbCar);
                    }

                }

                foreach (var item in dbCar.CarImages)
                {

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", item.Image);

                    FileHelper.DeleteFile(path);
                }


                List<CarImage> carImages = new();

                foreach (var photo in updatedCar.Photos)
                {
                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", fileName);

                    await FileHelper.SaveFileAsync(path, photo);

                    CarImage carImage = new()
                    {
                        Image = fileName
                    };

                    carImages.Add(carImage);

                }

                carImages.FirstOrDefault().IsMain = true;

                dbCar.CarImages = carImages;
            }


            decimal convertedPrice = decimal.Parse(updatedCar.Price);

            dbCar.Name = updatedCar.Name;
            dbCar.Description = updatedCar.Description;
            dbCar.ShortDescription = updatedCar.ShortDescription;
            dbCar.Extra = updatedCar.Extra;
            dbCar.Price = convertedPrice;
            dbCar.CarCategories = categories;
            dbCar.CarTags = tags;
            //dbCar.Updated = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
      


        private async Task<SelectList> GetCategoriesAsync()
        {

            IEnumerable<Category> categories = await _categoryService.GetAllAsync();

            return new SelectList(categories, "Id", "Name");

        }

        private async Task<SelectList> GetTagsAsync()
        {
            IEnumerable<Tag> tags = await _tagService.GetAllAsync();

            return new SelectList(tags, "Id", "Name");

        }


        private async Task<SelectList> GetCarClassAsync()
        {

            IEnumerable<CarClass> categories = await _carClassService.GetAllAsync();

            return new SelectList(categories, "Id", "Name");


        }


    }
}
