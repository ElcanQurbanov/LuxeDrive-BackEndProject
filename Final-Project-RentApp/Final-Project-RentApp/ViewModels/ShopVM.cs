using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.ViewModels
{
    public class ShopVM
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public Dictionary<string, string> SectionHeaders { get; set; }
    }
}
