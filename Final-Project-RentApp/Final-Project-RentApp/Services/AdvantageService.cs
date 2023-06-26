using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class AdvantageService : IAdvantageService
    {
        private readonly AppDbContext _context;

        public AdvantageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Advantage>> GetAllAsync() => await _context.Advantages.ToListAsync();

        public async Task<Advantage> GetByIdAsync(int id) => await _context.Advantages.FindAsync(id);

    }
}
