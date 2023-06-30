namespace Final_Project_RentApp.Services.Interfaces
{
    public interface IStaticDataService
    {
        Dictionary<string, string> GetAllSettings();
        Dictionary<string, string> GetAllSectionHeader();
    }
}
