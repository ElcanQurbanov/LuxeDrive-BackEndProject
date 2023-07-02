using Final_Project_RentApp.Areas.Admin.ViewModels;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ISliderService _sliderService;

        public SliderController(AppDbContext context,
                                IWebHostEnvironment env,
                                ISliderService sliderService)
        {
            _context = context;
            _env = env;
            _sliderService = sliderService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _sliderService.GetAllAsync();

            return View(sliders);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Slider slider = await _sliderService.GetByIdAsync((int)id);

            if (slider == null) return NotFound();

            return View(slider);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM slider)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                if (!slider.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File type must be image");
                    return View();
                }

                if (!slider.Photo.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photo", "Image size must be max 200kb");
                    return View();
                }

                string fileName = Guid.NewGuid().ToString() + "-" + slider.Photo.FileName;

                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", fileName);

                await FileHelper.SaveFileAsync(path, slider.Photo);

                Slider newSlider = new()
                {
                    Image = fileName,
                    //BackgroundImage = fileBackGroundName
                };

                await _context.Sliders.AddAsync(newSlider);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            catch (Exception)
            {
                throw;
            }
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    try
        //    {
        //        if (id == null) return BadRequest();

        //        Slider slider = await _sliderService.GetByIdAsync((int)id);

        //        if (slider is null) return NotFound();

        //        string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", slider.Image);

        //        FileHelper.DeleteFile(path);

        //        _context.Sliders.Remove(slider);

        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            Slider slider = await _sliderService.GetByIdAsync((int)id);

            if (slider is null) return NotFound();

            SliderEditVM model = new()
            {
                Id = slider.Id,
                Image = slider.Image,
                //BackGroundImage = slider.BackgroundImage
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SliderEditVM slider)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                if (id == null) return BadRequest();

                Slider dbSlider = await _sliderService.GetByIdAsync((int)id);

                if (slider is null) return NotFound();

                SliderEditVM model = new()
                {
                    Id = slider.Id,
                    Image = slider.Image,
                    //BackGroundImage = slider.BackGroundImage
                };

                if (slider.Photo != null)
                {
                    if (!slider.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "File type must be image");
                        return View(dbSlider);
                    }

                    if (!slider.Photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photo", "Image size must be max 200kb");
                        return View(dbSlider);
                    }

                    string oldPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/website-images", dbSlider.Image);

                    FileHelper.DeleteFile(oldPath);

                    string fileName = Guid.NewGuid().ToString() + "-" + slider.Photo.FileName;

                    string newPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/website-images", fileName);

                    await FileHelper.SaveFileAsync(newPath, slider.Photo);

                    dbSlider.Image = fileName;
                }
                else
                {
                    Slider newSlider = new()
                    {
                        Image = dbSlider.Image,
                        //BackgroundImage = dbSlider.BackgroundImage
                    };
                }

                //dbSlider.Title = slider.Title;


                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
