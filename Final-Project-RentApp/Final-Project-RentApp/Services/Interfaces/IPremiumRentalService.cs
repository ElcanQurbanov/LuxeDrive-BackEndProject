using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.Services.Interfaces
{
    public interface IPremiumRentalService
    {
        Task<PremiumRental> GetPremiumRentalAsync();
        Task<PremiumRental> GetByIdAsync(int id);
    }
}
