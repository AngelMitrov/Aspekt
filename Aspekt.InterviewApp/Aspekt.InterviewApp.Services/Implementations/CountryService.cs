using Aspekt.InterviewApp.DataAccess.Interfaces;
using Aspekt.InterviewApp.Domain.Models;
using Aspekt.InterviewApp.DTOs.ModelDTOs;
using Aspekt.InterviewApp.Mappers;
using Aspekt.InterviewApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspekt.InterviewApp.Services.Implementations
{
    public class CountryService : ICountryService
    {
        private ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public void CreateCountry(CountryDto country)
        {
            _countryRepository.Create(country.ToDomain());
        }

        public List<CountryDto> GetAllCountries()
        {
            List<Country> countries = _countryRepository.GetAll();

            List<CountryDto> countriesDto = new List<CountryDto>();

            foreach (Country item in countries)
            {
                countriesDto.Add(item.ToDto());
            }

            return countriesDto;
        }

        public void UpdateCountry(CountryDto country)
        {
            _countryRepository.Update(country.ToDomain());
        }

        public void DeleteCountry(int countryId)
        {
            _countryRepository.Delete(countryId);
        }
    }
}
