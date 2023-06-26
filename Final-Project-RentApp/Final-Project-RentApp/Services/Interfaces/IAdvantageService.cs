using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.Services.Interfaces
{
    public interface IAdvantageService
    {
        Task<IEnumerable<Advantage>> GetAllAsync();
        Task<Advantage> GetByIdAsync(int id);
    }
}
