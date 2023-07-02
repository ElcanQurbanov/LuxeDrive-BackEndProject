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
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Quarantee quarantee = await _context.Quarantees.Include(qi => qi.QuaranteeImages).FirstOrDefaultAsync(m => m.Id == id);

            //Quarantee quarantee = await _quaranteeService.GetByIdAsync((int)id);

            if (quarantee == null) return NotFound();

            return View(quarantee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(QuaranteeCreateVM quarantee)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View();
        //        }

        //        foreach (var photo in quarantee.Photos)
        //        {
        //            if (!photo.CheckFileType("image/"))
        //            {
        //                ModelState.AddModelError("Photo", "File type must be image");
        //                return View();
        //            }

        //            if (!photo.CheckFileSize(200))
        //            {
        //                ModelState.AddModelError("Photo", "Image size must be max 200kb");
        //                return View();
        //            }
        //        }

        //        foreach (var photo in quarantee.Photos)
        //        {
        //            string fileName = Guid.NewGuid().ToString() + "-" + photo.FileName;

        //            string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", fileName);

        //            await FileHelper.SaveFileAsync(path, photo);

        //            Quarantee newQuarantee = new()
        //            {
        //                QuaranteeImages = fileName,
        //                Name = team.Name,
        //                //Position = team.Position,
        //            };

        //            await _context.Teams.AddAsync(newTeam);
        //        }

        //        await _context.SaveChangesAsync();


        //        return RedirectToAction(nameof(Index));

        //    }

        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    try
        //    {
        //        if (id == null) return BadRequest();

        //        Quarantee quarantee = await _quaranteeService.GetByIdAsync((int)id);

        //        if (quarantee is null) return NotFound();

        //        string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", quarantee.Image);

        //        FileHelper.DeleteFile(path);

        //        _context.Teams.Remove(team);

        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}



    }
}
