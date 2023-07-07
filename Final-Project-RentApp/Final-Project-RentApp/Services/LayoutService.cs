using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public List<OrderItem> GetOrderItems()
        {
            List<OrderItem> order = _context.OrderItems.Include(o => o.AppUser).Include(x=>x.Car).ToList();
            return order;
        }

    }
}
