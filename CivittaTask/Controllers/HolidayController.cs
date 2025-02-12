using CivittaTask.Services.Interfaces;
using CivittaTask.Shared.DTOs;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CivittaTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;

        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        [HttpGet("holidays/grouped")]
        public async Task<Dictionary<int, List<HolidayDTO>>> GetHolidaysGroupedByMonth([FromQuery] string countryCode, [FromQuery] int year)
        {
            var groupedHolidays = await _holidayService.GetHolidaysGroupedByMonthAsync(countryCode, year);

            return groupedHolidays;
        }

        [HttpGet("isWorkingDay")]
        public async Task<DayDTO> IsWorkingDay([FromQuery] DateTime date, [FromQuery] string countryCode)
        {
            var day = await _holidayService.IsWorkingDayAsync(date, countryCode);

            return day;
        }

        [HttpGet("getMaxHolidaysInRow")]
        public async Task<int> GetMaxHolidaysInRow([FromQuery] string countryCode, [FromQuery] int year)
        {
            var countOfHolidays = await _holidayService.GetMaxConsecutiveHolidays(countryCode, year);

            return countOfHolidays;
        }
    }
}
