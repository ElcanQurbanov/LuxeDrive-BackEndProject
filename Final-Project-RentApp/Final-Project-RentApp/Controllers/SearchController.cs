using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Controllers
{   
    public class SearchController : Controller
    {
        private readonly ICarService _carService;

        public SearchController(ICarService carService)
        {
            _carService = carService;
        }

        //public async Task<IActionResult> Index(string searchString)
        //{
        //    if (_context.Movie == null)
        //    {
        //        return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
        //    }

        //    var movies = from m in _context.Movie
        //                 select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        movies = movies.Where(s => s.Title!.Contains(searchString));
        //    }

        //    return View(await movies.ToListAsync());
        //}

    }
}
