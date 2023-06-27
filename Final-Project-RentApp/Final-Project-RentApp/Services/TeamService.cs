using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class TeamService : ITeamService
    {
        private readonly AppDbContext _context;

        public TeamService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllAsync() => await _context.Teams.ToListAsync();

        public async Task<Team> GetByIdAsync(int id) => await _context.Teams.FindAsync(id);

    }
}
