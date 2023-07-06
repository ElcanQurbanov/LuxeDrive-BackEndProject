using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync() => await _context.OrderItems.ToListAsync();

        public async Task<OrderItem> GetByIdAsync(int id) => await _context.OrderItems.FindAsync(id);

    }
}
