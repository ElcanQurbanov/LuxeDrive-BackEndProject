using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.Services.Interfaces
{
    public interface IFaqService
    {
        Task<IEnumerable<Faq>> GetAllAsync();
        Task<Faq> GetByIdAsync(int id);
    }
}
