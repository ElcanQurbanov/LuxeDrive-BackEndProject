﻿using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;

        public CarService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllAsync() => await _context.Cars.Include(c => c.CarClass).Include(c => c.CarImages).Include(c => c.CarTags).ThenInclude(t => t.Tag).Include(cc => cc.CarCategories).ThenInclude(c => c.Category).ToListAsync();

        public async Task<Car> GetByIdAsync(int id) => await _context.Cars.Include(ci => ci.CarImages).Include(c => c.CarTags).ThenInclude(t => t.Tag).Include(c => c.CarCategories).ThenInclude(c => c.Category).Include(o=>o.OrderItems).Include(c => c.CarClass).Include(w=>w.WishlistItems).ThenInclude(x=>x.AppUser).Include(c => c.CarComments).FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<Car>> SearchAsync(string searchText) => await _context.Cars.Include(ci => ci.CarImages).Where(c => c.Name.Trim().ToLower().Contains(searchText.Trim().ToLower())).ToListAsync();
      

    }
}
