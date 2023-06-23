namespace Final_Project_RentApp.Models
{
    public class Quarantee : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public ICollection<QuaranteeImage> QuaranteeImages { get; set; }
    }
}
