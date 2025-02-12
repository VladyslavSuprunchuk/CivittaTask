using CivittaTask.DatabaseProvider.Entities;

namespace CivittaTask.DatabaseProvider.Interfaces
{
    public interface ICountryRepository
    {
        Task<bool> HasAnyAsync();

        List<Country> GetAll();

        Task AddRangeAsync(List<Country> countries);
    }
}
