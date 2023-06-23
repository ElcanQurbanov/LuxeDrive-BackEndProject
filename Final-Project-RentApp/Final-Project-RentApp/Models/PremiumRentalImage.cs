namespace Final_Project_RentApp.Models
{
    public class PremiumRentalImage : BaseEntity
    {
        public string Image { get; set; }
        public int PremiumRentalId { get; set; }
        public PremiumRental PremiumRental { get; set; }
    }
}
