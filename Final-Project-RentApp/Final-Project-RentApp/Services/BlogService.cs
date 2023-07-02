using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;

        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync() => await _context.Blogs.Include(i => i.BlogImages).ToListAsync();

        public async Task<Blog> GetByIdAsync(int id) => await _context.Blogs.Include(b=>b.BlogImages).FirstOrDefaultAsync(b => b.Id == id);

    }
}
