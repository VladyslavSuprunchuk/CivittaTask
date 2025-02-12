using AutoMapper;

using CivittaTask.DatabaseProvider.Entities;
using CivittaTask.DatabaseProvider.Interfaces;
using CivittaTask.Services.Interfaces;
using CivittaTask.Shared.DTOs;

namespace CivittaTask.Services.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IEnricoService _enricoClient;
        private readonly IHolidayRepository _holidayRepository;
        private readonly IMapper _mapper;
        private readonly IDayRepository _dayRepository;

        public HolidayService(
            IEnricoService enricoClient,
            IHolidayRepository holidayRepository,
            IMapper mapper,
            IDayRepository dayRepository)
        {
            _enricoClient = enricoClient;
            _holidayRepository = holidayRepository;
            _mapper = mapper;
            _dayRepository = dayRepository;
        }

        public async Task<DayDTO> IsWorkingDayAsync(DateTime date, string countryCode)
        {
            var isAnyRecordInDb = await _dayRepository.HasAnyAsync(countryCode, date);

            if (isAnyRecordInDb) 
            {
                var dayFromDb = await _dayRepository.GetAsync(countryCode, date);
                var day = _mapper.Map<DayDTO>(dayFromDb);

                return day;
            }

            var dayFromClient = await _enricoClient.IsWorkingDayAsync(date, countryCode);

            if (dayFromClient is not null)
            {
                var day = _mapper.Map<Day>(dayFromClient, opts =>
                {
                    opts.Items["CountryCode"] = countryCode;
                    opts.Items["Date"] = date;
                });
                await _dayRepository.AddAsync(day);
            }

            return dayFromClient;
        }

        public async Task<Dictionary<int, List<HolidayDTO>>> GetHolidaysGroupedByMonthAsync(string countryCode, int year)
        {
            var isAnyRecordInDb = await _holidayRepository.HasAnyAsync(countryCode, year);
            var holidays = new List<HolidayDTO>();

            if (isAnyRecordInDb)
            {
                var holidaysFromDb = _holidayRepository.GetAll();
                holidays = _mapper.Map<List<HolidayDTO>>(holidaysFromDb);
            }
            else
            {
                holidays = await _enricoClient.GetHolidaysAsync(countryCode, year);

                if (holidays.Any())
                {
                    var holidaysToSave = _mapper.Map<List<Holiday>>(holidays);
                    holidaysToSave.ForEach(x => x.CountryCode = countryCode);
                    await _holidayRepository.AddRangeAsync(holidaysToSave);
                }
            }

            return holidays
                .GroupBy(h => h.Date.Month)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public async Task<int> GetMaxConsecutiveHolidays(string countryCode, int year)
        {
            var isAnyRecordInDb = await _holidayRepository.HasAnyAsync(countryCode, year);
            var holidays = new List<HolidayDTO>();

            if (isAnyRecordInDb)
            {
                var holidaysFromDb = _holidayRepository.GetAll();
                holidays = _mapper.Map<List<HolidayDTO>>(holidaysFromDb);
            }
            else
            {
                holidays = await _enricoClient.GetHolidaysAsync(countryCode, year);

                if (holidays.Any())
                {
                    var holidaysToSave = _mapper.Map<List<Holiday>>(holidays);
                    holidaysToSave.ForEach(x => x.CountryCode = countryCode);
                    await _holidayRepository.AddRangeAsync(holidaysToSave);
                }
            }

            var holidaysInRow = CalculateMaxConsecutiveHolidays(holidays);

            return holidaysInRow;
        }

        public static int CalculateMaxConsecutiveHolidays(List<HolidayDTO> holidays)
        {
            if (holidays == null || holidays.Count == 0)
                return 0;

            int maxConsecutive = 1;
            int currentConsecutive = 1;

            for (int i = 1; i < holidays.Count; i++)
            {
                DateTime currentDate = new DateTime(holidays[i].Date.Year, holidays[i].Date.Month, holidays[i].Date.Day);
                DateTime previousDate = new DateTime(holidays[i - 1].Date.Year, holidays[i - 1].Date.Month, holidays[i - 1].Date.Day);

                if ((currentDate - previousDate).Days == 1)
                {
                    currentConsecutive++;
                    if (currentConsecutive > maxConsecutive)
                    {
                        maxConsecutive = currentConsecutive;
                    }
                }
                else
                {
                    currentConsecutive = 1;
                }
            }

            return maxConsecutive;
        }
    }
}
