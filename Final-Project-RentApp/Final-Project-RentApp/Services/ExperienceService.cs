using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly AppDbContext _context;

        public ExperienceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Experience>> GetAllAsync() => await _context.Experiences.ToListAsync();

        public async Task<Experience> GetByIdAsync(int id) => await _context.Experiences.FindAsync(id);

    }
}
