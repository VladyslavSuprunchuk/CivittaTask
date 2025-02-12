using CivittaTask.DatabaseProvider.Entities;
using CivittaTask.DatabaseProvider.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace CivittaTask.DatabaseProvider.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _dataContext;

        public CountryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Country> GetAll()
        {
            var countries = _dataContext
                .Countries
                .Include(x => x.FromDate)
                .Include(x => x.ToDate)
                .Include(x => x.Regions)
                .Include(x => x.HolidayTypes).ToList();

            return countries;
        }

        public async Task<bool> HasAnyAsync()
        {
            var result = await _dataContext.Countries.AnyAsync();
            
            return result;
        }

        public async Task AddRangeAsync(List<Country> countries)
        {
            foreach (var country in countries) 
            {
                await _dataContext.Countries.AddAsync(country);
            }

            await _dataContext.SaveChangesAsync();
        }
    }
}
