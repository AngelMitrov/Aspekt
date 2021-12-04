using Aspekt.InterviewApp.DTOs.ModelDTOs;
using Aspekt.InterviewApp.DTOs.OtherDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspekt.InterviewApp.Services.Interfaces
{
    public interface IContactService
    {
        void CreateContact(ContactDto contact);
        List<ContactDto> GetAllContacts();
        void UpdateContact(ContactDto contact);
        void DeleteContact(int contactId);
        List<ContactInfoDto> GetContactsWithCompanyAndCountry();
        List<ContactDto> FilterContact(int? countryId, int? companyId);

    }
}
