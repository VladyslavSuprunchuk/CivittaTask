using CivittaTask.Shared.DTOs;

namespace CivittaTask.Services.Interfaces
{
    public interface IEnricoService
    {
        Task<List<CountryDTO>> GetCountriesAsync();

        Task<List<HolidayDTO>> GetHolidaysAsync(string countryCode, int year);

        Task<DayDTO> IsWorkingDayAsync(DateTime dateTime, string countryCode);
    }
}
