using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class CarClassService : ICarClassService
    {
        private readonly AppDbContext _context;

        public CarClassService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarClass>> GetAllAsync() => await _context.CarClasses.Include(i => i.CarClassInfos).ToListAsync();

        public async Task<CarClass> GetByIdAsync(int id) => await _context.CarClasses.FindAsync(id);

    }
}
