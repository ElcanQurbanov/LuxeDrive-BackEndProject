using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;

        public CarService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllAsync() => await _context.Cars.Include(c => c.CarClass).Include(c => c.CarImages).ToListAsync();

        public async Task<Car> GetByIdAsync(int id) => await _context.Cars.Include(ci => ci.CarImages).FirstOrDefaultAsync(c => c.Id == id);

    }
}
