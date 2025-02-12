using CivittaTask.DatabaseProvider.Entities;
using CivittaTask.DatabaseProvider.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace CivittaTask.DatabaseProvider.Repositories
{
    public class DayRepository : IDayRepository
    {
        private readonly DataContext _dataContext;

        public DayRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Day> GetAsync(string countryCode, DateTime dateTime)
        {
            var result = await _dataContext.Days.FirstOrDefaultAsync(x => x.Date == dateTime && x.CountryCode == countryCode);

            return result;
        }

        public async Task AddAsync(Day day)
        {
             await _dataContext.Days.AddAsync(day);

            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> HasAnyAsync(string countryCode, DateTime dateTime)
        {
            var result = await _dataContext.Days.AnyAsync(x => x.Date == dateTime && x.CountryCode == countryCode);

            return result;
        }
    }
}
