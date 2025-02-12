using AutoMapper;

using CivittaTask.DatabaseProvider.Entities;
using CivittaTask.DatabaseProvider.Interfaces;
using CivittaTask.Services.Interfaces;
using CivittaTask.Shared.DTOs;

namespace CivittaTask.Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly IEnricoService _enricoClient;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(IEnricoService enricoClient, ICountryRepository countryRepository, IMapper mapper)
        {
            _enricoClient = enricoClient;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<List<CountryDTO>> GetCountriesAsync()
        {
            var isAnyRecordInDb = await _countryRepository.HasAnyAsync();

            if (isAnyRecordInDb)
            {
                var countriesFromDb = _countryRepository.GetAll();
                var countries = _mapper.Map<List<CountryDTO>>(countriesFromDb);

                return countries;
            }

            var countriesFromClient = await _enricoClient.GetCountriesAsync();

            if (countriesFromClient.Any())
            {
                var countries = _mapper.Map<List<Country>>(countriesFromClient);
                await _countryRepository.AddRangeAsync(countries);
            }

            return countriesFromClient;
        }
    }
}
