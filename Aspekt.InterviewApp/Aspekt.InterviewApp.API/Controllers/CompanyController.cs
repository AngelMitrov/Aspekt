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
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("add")]
        public ActionResult CreateCompany(CompanyDto companyDto)
        {
            _companyService.CreateCompany(companyDto);
            return StatusCode(StatusCodes.Status201Created, "Successfully Added New Company!");
        }


        [HttpGet("all")]
        public ActionResult<List<CompanyDto>> GetAllCompanies()
        {
            List<CompanyDto> companies = _companyService.GetAllCompanies();
            return StatusCode(StatusCodes.Status200OK, companies);
        }

        [HttpDelete("{id}/delete")]
        public ActionResult DeleteCompany(int id)
        {

            _companyService.DeleteCompany(id);
            return StatusCode(StatusCodes.Status200OK, "Company Successfully Deleted");
        }

        [HttpPost("update")]
        public ActionResult UpdateCompany(CompanyDto companyDto)
        {
            _companyService.UpdateCompany(companyDto);
            return StatusCode(StatusCodes.Status202Accepted, $"Successfully Updated Company with ID: {companyDto.Id}");
        }
    }
}
