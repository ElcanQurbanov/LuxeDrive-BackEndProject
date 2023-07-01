using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class TagService : ITagService
    {
        private readonly AppDbContext _context;

        public TagService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync() => await _context.Tags.Include(ct => ct.CarTags).ThenInclude(c => c.Car).ToListAsync();

        public async Task<Tag> GetByIdAsync(int id) => await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);

    }
}
