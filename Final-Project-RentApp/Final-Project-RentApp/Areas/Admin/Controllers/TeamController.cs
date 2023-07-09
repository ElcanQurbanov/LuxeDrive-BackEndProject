using Final_Project_RentApp.Areas.Admin.ViewModels;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ITeamService _teamService;

        public TeamController(AppDbContext context,
                              IWebHostEnvironment env,
                              ITeamService teamService)
        {
            _context = context;
            _env = env;
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Team> teams = await _teamService.GetAllAsync();

            return View(teams);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Team team = await _teamService.GetByIdAsync((int)id);

            if (team == null) return NotFound();

            return View(team);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamCreateVM team)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                foreach (var photo in team.Photos)
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

                foreach (var photo in team.Photos)
                {
                    string fileName = Guid.NewGuid().ToString() + "-" + photo.FileName;

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", fileName);

                    await FileHelper.SaveFileAsync(path, photo);

                    Team newTeam = new()
                    {
                        Image = fileName,
                        Name = team.Name,
                        Phone = team.Phone
                    };

                    await _context.Teams.AddAsync(newTeam);
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

                Team team = await _teamService.GetByIdAsync((int)id);

                if (team is null) return NotFound();

                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", team.Image);

                FileHelper.DeleteFile(path);

                _context.Teams.Remove(team);

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

            Team team = await _teamService.GetByIdAsync((int)id);

            if (team is null) return NotFound();

            TeamEditVM model = new()
            {
                Id = team.Id,
                Name = team.Name,
                Image = team.Image,
                Phone = team.Phone,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, TeamEditVM team)
        {
            try
            {

                if (id == null) return BadRequest();

                Team dbTeam = await _teamService.GetByIdAsync((int)id);

                if (team is null) return NotFound();

                if (!ModelState.IsValid)
                {
                    team.Image = dbTeam.Image;

                    return View(team);
                }


                TeamEditVM model = new()
                {
                    Id = team.Id,
                    Name = team.Name,
                    Image = team.Image,
                    Phone = team.Phone,
                };

                if (team.Photo != null)
                {
                    if (!team.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "File type must be image");
                        return View(dbTeam);
                    }

                    if (!team.Photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photo", "Image size must be max 200kb");
                        return View(dbTeam);
                    }

                    string oldPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", dbTeam.Image);

                    FileHelper.DeleteFile(oldPath);

                    string fileName = Guid.NewGuid().ToString() + "-" + team.Photo.FileName;

                    string newPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/home", fileName);

                    await FileHelper.SaveFileAsync(newPath, team.Photo);

                    dbTeam.Image = fileName;
                }
                else
                {
                    Team newTeam = new()
                    {
                        Image = dbTeam.Image
                    };
                }

                dbTeam.Name = team.Name;
                dbTeam.Phone = team.Phone;


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
