using Sales.Shared;

namespace Sales.API.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;

        public SeedDB(DataContext context)
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
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country { Name = "Colombia" });
                _context.Countries.Add(new Country { Name = "Estados Unidos" });
                _context.Countries.Add(new Country { Name = "Perú" });
                _context.Countries.Add(new Country { Name = "Mexico" });
            }
            else
            {
                if(!_context.Countries.Any(x=>x.Name== "Colombia"))
                {
                    _context.Countries.Add(new Country { Name = "Colombia" });
                }
                if (!_context.Countries.Any(x => x.Name == "Estados Unidos"))
                {
                    _context.Countries.Add(new Country { Name = "Estados Unidos" });
                }
                if (!_context.Countries.Any(x => x.Name == "Perú"))
                {
                    _context.Countries.Add(new Country { Name = "Perú" });
                }
                if (!_context.Countries.Any(x => x.Name == "Mexico"))
                {
                    _context.Countries.Add(new Country { Name = "Mexico" });
                }
            }

            await _context.SaveChangesAsync();
        }
    }

}

