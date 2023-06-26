using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.Services.Interfaces
{
    public interface IComfortService
    {
        Task<Comfort> GetComfortAsync();
        Task<Comfort> GetByIdAsync(int id);
    }
}
