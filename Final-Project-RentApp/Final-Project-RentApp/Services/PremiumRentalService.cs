using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class PremiumRentalService : IPremiumRentalService
    {
        private readonly AppDbContext _context;

        public PremiumRentalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PremiumRental> GetByIdAsync(int id) => await _context.PremiumRentals.FindAsync(id);

        public async Task<PremiumRental> GetPremiumRentalAsync() => await _context.PremiumRentals.Include(i => i.PremiumRentalImages).FirstOrDefaultAsync();

    }
}
