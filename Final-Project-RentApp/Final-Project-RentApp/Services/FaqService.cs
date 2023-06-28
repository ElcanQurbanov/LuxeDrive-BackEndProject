using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class FaqService : IFaqService
    {
        private readonly AppDbContext _context;

        public FaqService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Faq>> GetAllAsync() => await _context.Faqs.ToListAsync();

        public async Task<Faq> GetByIdAsync(int id) => await _context.Faqs.FindAsync(id);

    }
}
