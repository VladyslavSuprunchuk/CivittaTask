using CivittaTask.DatabaseProvider.Entities;
using System.Threading.Tasks;

namespace CivittaTask.DatabaseProvider.Interfaces
{
    public interface IDayRepository
    {
        Task<bool> HasAnyAsync(string countryCode, DateTime dateTime);

        Task AddAsync(Day day);

        Task<Day> GetAsync(string countryCode, DateTime dateTime);
    }
}
