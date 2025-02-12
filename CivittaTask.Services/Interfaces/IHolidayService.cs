using CivittaTask.Shared.DTOs;

namespace CivittaTask.Services.Interfaces
{
    public interface IHolidayService
    {
        Task<Dictionary<int, List<HolidayDTO>>> GetHolidaysGroupedByMonthAsync(string countryCode, int year);

        Task<DayDTO> IsWorkingDayAsync(DateTime date, string countryCode);

        Task<int> GetMaxConsecutiveHolidays(string countryCode, int year)ж
    }
}
