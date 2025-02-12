using CivittaTask.DatabaseProvider.Entities;

namespace CivittaTask.DatabaseProvider.Interfaces
{
    public interface IHolidayRepository
    {
        List<Holiday> GetAll();

        Task<bool> HasAnyAsync(string countryCode, int year);

        Task AddRangeAsync(List<Holiday> holidays);
    }
}
