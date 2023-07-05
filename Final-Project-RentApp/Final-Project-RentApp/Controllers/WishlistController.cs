using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Controllers
{
    public class WishlistController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICarService _carService;

        public WishlistController(AppDbContext context,UserManager<AppUser> userManager, ICarService carService)
        {
            _context = context;
            _userManager = userManager;
            _carService = carService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddWishList(int? id)
        {
            TempData["Wishlist"] = false;

            if (id == 0) return BadRequest();

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                Car car = await _carService.GetByIdAsync((int)id);

                bool dublicate = _context.WishlistItems.Include(x => x.Car).Any(x => x.CarId == car.Id);

                if (dublicate == true) return Redirect(Request.Headers["Referer"].ToString());

                WishlistItem wishlistItem = new()
                {
                    CarId = car.Id,
                    AppUserId = user.Id,
                };

                _context.WishlistItems.Add(wishlistItem);

                _context.SaveChanges();
            }
            else
            {
                return RedirectToAction("login", "account");
            }

            TempData["Wishlist"] = true;

            return Redirect(Request.Headers["Referer"].ToString());
        }


    }
}
