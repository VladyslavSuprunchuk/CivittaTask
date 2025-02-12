using CivittaTask.DatabaseProvider.Entities;
using CivittaTask.DatabaseProvider.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace CivittaTask.DatabaseProvider.Repositories
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly DataContext _dataContext;

        public HolidayRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Holiday> GetAll()
        {
            var holidays = _dataContext
                .Holidays
                .Include(x => x.Date)
                .Include(x => x.Name).ToList();

            return holidays;
        }

        public async Task<bool> HasAnyAsync(string countryCode, int year)
        {
            var result = await _dataContext.Holidays.AnyAsync(x => x.Date.Year == year && x.CountryCode == countryCode);

            return result;
        }

        public async Task AddRangeAsync(List<Holiday> holidays)
        {
            foreach (var holiday in holidays)
            {
                await _dataContext.Holidays.AddAsync(holiday);
            }

            await _dataContext.SaveChangesAsync();
        }
    }
}
