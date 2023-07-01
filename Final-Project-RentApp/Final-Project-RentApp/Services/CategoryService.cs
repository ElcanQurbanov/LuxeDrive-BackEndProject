using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.Include(cc => cc.CarCategories).ThenInclude(c => c.Car).ToListAsync();

        public async Task<Category> GetByIdAsync(int id) => await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

    }
}
