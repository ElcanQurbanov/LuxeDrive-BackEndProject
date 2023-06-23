namespace Final_Project_RentApp.Models
{
    public class QuaranteeImage : BaseEntity
    {
        public string Image { get; set; }
        public int QuaranteeId { get; set; }
        public Quarantee Quarantee { get; set; }
    }
}
