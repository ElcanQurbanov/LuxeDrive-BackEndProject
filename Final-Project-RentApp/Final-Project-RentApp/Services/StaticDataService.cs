using Final_Project_RentApp.Data;
using Final_Project_RentApp.Services.Interfaces;

namespace Final_Project_RentApp.Services
{
    public class StaticDataService : IStaticDataService
    {
        private readonly AppDbContext _context;

        public StaticDataService(AppDbContext context)
        {
            _context = context;
        }

        public Dictionary<string, string> GetAllSectionHeader() =>  _context.SectionHeaders.AsEnumerable().ToDictionary(sh => sh.Key, sh => sh.Value);

        public Dictionary<string, string> GetAllSettings() => _context.Settings.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);

    }
}
