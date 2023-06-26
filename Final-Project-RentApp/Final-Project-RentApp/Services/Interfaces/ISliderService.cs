using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.Services.Interfaces
{
    public interface ISliderService
    {
        Task<IEnumerable<Slider>> GetAllAsync();
        Task<Slider> GetByIdAsync(int id);
    }
}
