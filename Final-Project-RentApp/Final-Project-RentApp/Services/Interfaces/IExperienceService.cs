using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.Services.Interfaces
{
    public interface IExperienceService
    {
        Task<IEnumerable<Experience>> GetAllAsync();
        Task<Experience> GetByIdAsync(int id);
    }
}
