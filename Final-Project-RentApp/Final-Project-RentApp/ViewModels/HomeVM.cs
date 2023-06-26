using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public Comfort Comfort { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Advantage> Advantages { get; set; }
        public Quarantee Quarantee { get; set; }
        public PremiumRental PremiumRental { get; set; }
    }
}
