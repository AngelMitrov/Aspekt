using Aspekt.InterviewApp.DTOs.ModelDTOs;
using Aspekt.InterviewApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspekt.InterviewApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryService _countryController;

        public CountryController(ICountryService countryController)
        {
            _countryController = countryController;
        }

        [HttpPost("add")]
        public ActionResult CreateCountry(CountryDto countryDto)
        {
            _countryController.CreateCountry(countryDto);
            return StatusCode(StatusCodes.Status201Created, "Successfully Added New Country!");
        }


        [HttpGet("all")]
        public ActionResult<List<CountryDto>> GetAllCountries()
        {
            List<CountryDto> countries = _countryController.GetAllCountries();
            return StatusCode(StatusCodes.Status200OK, countries);
        }

        [HttpDelete("{id}/delete")]
        public ActionResult DeleteCountry(int id)
        {
            _countryController.DeleteCountry(id);
            return StatusCode(StatusCodes.Status200OK, "Country Successfully Deleted");
        }

        [HttpPost("update")]
        public ActionResult UpdateCountry(CountryDto countryDto)
        {
            _countryController.UpdateCountry(countryDto);
            return StatusCode(StatusCodes.Status202Accepted, $"Successfully Updated Country with ID: {countryDto.Id}");
        }
    }
}
