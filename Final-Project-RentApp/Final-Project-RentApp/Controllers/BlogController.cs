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

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Blog> blogs = await _blogService.GetAllAsync();

            BlogVM model = new()
            {
                Blogs = blogs
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
