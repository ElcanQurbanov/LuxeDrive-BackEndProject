using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Controllers
{
    [Authorize]
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
            if (!User.Identity.IsAuthenticated)
            {
                return View(new List<WishlistItem>());
            }

            var userId = _userManager.GetUserId(User);

            var wishListItems = _context.WishlistItems
                                        .Include(wli => wli.Car)
                                        .ThenInclude(p => p.CarImages)
                                        .Include(wli => wli.Car)
                                        .ThenInclude(p => p.CarClass)
                                        .Where(wli => wli.AppUserId == userId)
                                        .ToList();

            if (wishListItems.Count == 0)
            {
                return View(new List<WishlistItem>());
            }

            return View(wishListItems);
        }

        public async Task<IActionResult> AddWishList(int? id)
        {
            TempData["Wishlist"] = false;

            if (id == 0) return BadRequest();

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                Car car = await _carService.GetByIdAsync((int)id);

                bool dublicate = _context.WishlistItems.Any(m =>m.AppUserId==user.Id && m.CarId == car.Id);

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

        public async Task<IActionResult> RemoveFromWishList(int wishListItemId)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            WishlistItem wishListItem = await _context.WishlistItems.FirstOrDefaultAsync(x => x.AppUserId == user.Id && x.Id == wishListItemId);

            if (wishListItem is null)
            {
                return NotFound();
            }

            _context.WishlistItems.Remove(wishListItem);

            await _context.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }


    }
}
