using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.Services.Interfaces
{
    public interface ICarClassService
    {
        Task<IEnumerable<CarClass>> GetAllAsync();
        Task<CarClass> GetByIdAsync(int id);
    }
}
