using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.Services.Interfaces
{
    public interface IQuaranteeService
    {
        Task<Quarantee> GetQuaranteeAsync();
    }
}
