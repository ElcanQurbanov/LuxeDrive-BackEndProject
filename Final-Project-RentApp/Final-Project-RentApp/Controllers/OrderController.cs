using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            IEnumerable<OrderItem> orderItem = _context.OrderItems.
                                                 Include(x => x.Car).
                                                 ThenInclude(x=>x.CarImages).
                                                 Include(x => x.Car).
                                                 ThenInclude(x => x.CarClass).
                                                 Include(x => x.AppUser).
                                                 Where(x => x.AppUserId == user.Id).
                                                 ToList();

            return View(orderItem);

            
        }

    }
}
