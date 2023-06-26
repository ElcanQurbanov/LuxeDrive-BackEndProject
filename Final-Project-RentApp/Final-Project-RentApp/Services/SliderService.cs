using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;

        public SliderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Slider>> GetAllAsync() => await _context.Sliders.ToListAsync();

        public async Task<Slider> GetByIdAsync(int id) => await _context.Sliders.FindAsync(id);
     
    }
}
