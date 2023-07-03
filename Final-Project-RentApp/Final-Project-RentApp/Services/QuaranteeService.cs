using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class QuaranteeService : IQuaranteeService
    {
        private readonly AppDbContext _context;

        public QuaranteeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Quarantee> GetQuaranteeAsync() => await _context.Quarantees.Include(i => i.QuaranteeImages).FirstOrDefaultAsync();

    }
}
