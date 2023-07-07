using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public OrderController(AppDbContext context,IEmailService emailService)
        {
            _context = context;
           _emailService = emailService;
        }
        public IActionResult Index()
        {
            IEnumerable<OrderItem> orders = _context.OrderItems.Include(x=>x.Car).ToList();

            return View(orders);
        }

        public IActionResult Edit(int id)
        {
            OrderItem order = _context.OrderItems.Include(o => o.AppUser).Include(x=>x.Car).ThenInclude(x=>x.CarImages).FirstOrDefault(o => o.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        public IActionResult Accept(int id)
        {
           OrderItem order = _context.OrderItems.Include(x => x.AppUser).Include(x=>x.Car).FirstOrDefault(o => o.Id == id);

            if (order == null) return  NotFound();

            order.Status = OrderStatus.Accepted;

            _context.SaveChanges();

            string recipientEmail = order.AppUser.Email;
            string subject = "Your order has been accepted";
            string body = "Your order has been accepted. Thank you! The total amount to be paid is " + order.Car.Price + "$";

            _emailService.Send(recipientEmail, subject, body);

            return RedirectToAction("Index", "Order");

        }

        public IActionResult Reject(int id)
        {
            OrderItem order = _context.OrderItems.Include(x => x.AppUser).Include(x => x.Car).FirstOrDefault(o => o.Id == id);

            if (order == null) return NotFound();

            order.Status = OrderStatus.Rejected;

            _context.SaveChanges();

            string recipientEmail = order.AppUser.Email;
            string subject = "Your order has been rejected";
            string body = "You can rent the car in advance and see other cars on the date you mentioned";


            _emailService.Send( recipientEmail,subject, body);

            return RedirectToAction("Index", "Order");

        }
    }
}
