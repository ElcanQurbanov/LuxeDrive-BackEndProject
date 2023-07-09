using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services;
using Final_Project_RentApp.Services.Interfaces;
using Final_Project_RentApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IStaticDataService _staticDataService;

        public BlogController(IBlogService blogService,
                              IStaticDataService staticDataService)
        {
            _blogService = blogService;
            _staticDataService = staticDataService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Blog> blogs = await _blogService.GetAllAsync();
            Dictionary<string, string> sectionHeaders = _staticDataService.GetAllSectionHeader();

            BlogVM model = new()
            {
                Blogs = blogs,
                SectionHeaders = sectionHeaders
            };

            return View(model);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Blog blog = await _blogService.GetByIdAsync((int)id);

            if (blog == null) return NotFound();

            return View(blog);
        }

       
    }
}
