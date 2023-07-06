using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.Services.Interfaces
{
    public interface IWishlistService
    {
        Task<IEnumerable<WishlistItem>> GetAllAsync();
        Task<WishlistItem> GetByIdAsync(int id);
    }
}
