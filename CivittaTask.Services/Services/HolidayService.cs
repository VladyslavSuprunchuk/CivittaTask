using AutoMapper;

using CivittaTask.DatabaseProvider.Entities;
using CivittaTask.DatabaseProvider.Interfaces;
using CivittaTask.DatabaseProvider.Repositories;
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
    }
}
