using CivittaTask.Services.Interfaces;
using CivittaTask.Shared.Const;
using CivittaTask.Shared.DTOs;

using System.Text.Json;

namespace CivittaTask.Services.Services
{
    public class EnricoService : IEnricoService
    {
        private readonly HttpClient _httpClient;

        public EnricoService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient(HttpClientKeywords.EnricoClientName);
        }

        public async Task<List<CountryDTO>> GetCountriesAsync()
        {
            var response = await _httpClient.GetAsync("?action=getSupportedCountries");

            if (!response.IsSuccessStatusCode)
                return new List<CountryDTO>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<CountryDTO>>(json);

            return result;
        }

        public async Task<List<HolidayDTO>> GetHolidaysAsync(string countryCode, int year)
        {
            var response = await _httpClient.GetAsync($"?action=getHolidaysForYear&year={year}&country={countryCode}");

            if (!response.IsSuccessStatusCode)
                return new List<HolidayDTO>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<HolidayDTO>>(json);

            return result;
        }

        public async Task<DayDTO> IsWorkingDayAsync(DateTime dateTime, string countryCode)
        {
            var date = dateTime.ToString("dd-MM-yyyy");
            var response = await _httpClient.GetAsync($"?action=isWorkDay&date={date}&country={countryCode}");

            if (!response.IsSuccessStatusCode)
                return new DayDTO();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<DayDTO>(json);

            return result;
        }
    }
}
