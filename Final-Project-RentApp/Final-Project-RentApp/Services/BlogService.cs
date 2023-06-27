using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;

namespace Final_Project_RentApp.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;

        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Blog>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Blog> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
