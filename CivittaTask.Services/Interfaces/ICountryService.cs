using CivittaTask.Shared.DTOs;

using System.Diagnostics.Metrics;

namespace CivittaTask.Services.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryDTO>> GetCountriesAsync();
    }
}
