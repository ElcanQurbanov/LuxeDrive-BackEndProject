using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly AppDbContext _context;

        public WishlistService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WishlistItem>> GetAllAsync() => await _context.WishlistItems.ToListAsync();

        public async Task<WishlistItem> GetByIdAsync(int id) => await _context.WishlistItems.FindAsync(id);

    }
}
