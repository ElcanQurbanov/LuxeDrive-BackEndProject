using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class ComfortService : IComfortService
    {
        private readonly AppDbContext _context;

        public ComfortService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comfort> GetComfortAsync() => await _context.Comforts.FirstOrDefaultAsync();

    }
}
