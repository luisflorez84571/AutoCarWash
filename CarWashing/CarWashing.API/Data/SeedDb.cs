using CarWashing.Shared.Entities;

namespace CarWashing.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Clients.Any())
            {
                _context.Clients.Add(new Client { FirstName = "Fernando" });
                _context.Clients.Add(new Client { FirstName = "Luis" });
            }

            await _context.SaveChangesAsync();
        }
    }
}

