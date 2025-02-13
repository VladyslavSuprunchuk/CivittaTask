using CivittaTask.Services.Interfaces;
using CivittaTask.Shared.DTOs;

using Microsoft.AspNetCore.Mvc;

namespace CivittaTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryDTO>> Get()
        {
            var countries = await _countryService.GetCountriesAsync();

            return countries;
        }
    }
}
