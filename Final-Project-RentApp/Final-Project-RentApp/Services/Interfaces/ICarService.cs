using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int id);
    }
}
