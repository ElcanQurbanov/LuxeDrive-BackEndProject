using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
