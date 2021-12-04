using Aspekt.InterviewApp.DTOs.ModelDTOs;
using Aspekt.InterviewApp.DTOs.OtherDTOs;
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
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("add")]
        public ActionResult CreateContact(ContactDto contactDto)
        {
            _contactService.CreateContact(contactDto);
            return StatusCode(StatusCodes.Status201Created, "Successfully Added New Contact!");
        }


        [HttpGet("all")]
        public ActionResult<List<ContactDto>> GetAllContacts()
        {
            List<ContactDto> contacts = _contactService.GetAllContacts();
            return StatusCode(StatusCodes.Status200OK, contacts);
        }

        [HttpDelete("{id}/delete")]
        public ActionResult DeleteContact(int id)
        {
            _contactService.DeleteContact(id);
            return StatusCode(StatusCodes.Status200OK, "Contact Successfully Deleted");
        }

        [HttpPost("update")]
        public ActionResult UpdateContact(ContactDto contactDto)
        {
            _contactService.UpdateContact(contactDto);
            return StatusCode(StatusCodes.Status202Accepted, $"Successfully Updated Contact with ID: {contactDto.Id}");
        }

        [HttpGet("filter/{countryId}/{companyId}")]
        public ActionResult<List<ContactDto>> FilterContacts(int countryId, int companyId)
        {
            List<ContactDto> filteredContacts = _contactService.FilterContact(countryId, companyId);
            return StatusCode(StatusCodes.Status202Accepted, filteredContacts);
        }

        [HttpGet("filterbycountry/{countryId}")]
        public ActionResult<List<ContactDto>> FilterContactsByCountry(int countryId)
        {
            List<ContactDto> filteredContacts = _contactService.FilterContact(countryId, null);
            return StatusCode(StatusCodes.Status202Accepted, filteredContacts);
        }
        
        [HttpGet("filterbycompany/{companyId}")]
        public ActionResult<List<ContactDto>> FilterContactsByCompany(int companyId)
        {
            List<ContactDto> filteredContacts = _contactService.FilterContact(null, companyId);
            return StatusCode(StatusCodes.Status202Accepted, filteredContacts);
        }

        [HttpGet("getcontactwithcompanyandcountry")]
        public ActionResult<List<ContactInfoDto>> GetContactWithCompanyAndCountry()
        {
            List<ContactInfoDto> contacts = _contactService.GetContactsWithCompanyAndCountry();
            return StatusCode(StatusCodes.Status202Accepted, contacts);
        }
    }
}
