namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class SliderEditVM
    {
        public int Id { get; set; }
        //[Required]

        public string Image { get; set; }
        public IFormFile Photo { get; set; }

        //public string BackGroundImage { get; set; }
        //public IFormFile BackGroundPhoto { get; set; }
    }
}
