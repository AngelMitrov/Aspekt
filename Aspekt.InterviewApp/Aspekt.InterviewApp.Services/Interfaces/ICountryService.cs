using Aspekt.InterviewApp.DTOs.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspekt.InterviewApp.Services.Interfaces
{
    public interface ICountryService
    {
        void CreateCountry(CountryDto country);
        List<CountryDto> GetAllCountries();
        void UpdateCountry(CountryDto country);
        void DeleteCountry(int countryId);
    }
}
