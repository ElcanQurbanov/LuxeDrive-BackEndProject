using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;

namespace Final_Project_RentApp.Services
{
    public class TagService : ITagService
    {
        
        public Task<IEnumerable<Tag>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
