using Aspekt.InterviewApp.DataAccess.Interfaces;
using Aspekt.InterviewApp.Domain.Models;
using Aspekt.InterviewApp.DTOs.ModelDTOs;
using Aspekt.InterviewApp.DTOs.OtherDTOs;
using Aspekt.InterviewApp.Mappers;
using Aspekt.InterviewApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspekt.InterviewApp.Services.Implementations
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void CreateContact(ContactDto contact)
        {
            _contactRepository.Create(contact.ToDomain());
        }

        public List<ContactDto> GetAllContacts()
        {
            List<Contact> contacts = _contactRepository.GetAll();

            List<ContactDto> contactsDto = new List<ContactDto>();

            foreach (Contact item in contacts)
            {
                contactsDto.Add(item.ToDto());
            }

            return contactsDto;
        }

        public void UpdateContact(ContactDto contact)
        {
            _contactRepository.Update(contact.ToDomain());
        }

        public void DeleteContact(int contactId)
        {
            _contactRepository.Delete(contactId);
        }

        public List<ContactInfoDto> GetContactsWithCompanyAndCountry()
        {
            List<ContactInfoDto> contactInfos = new List<ContactInfoDto>();
            List<Contact> contacts = _contactRepository.GetAll().Where(x => x.Country != null && x.Company != null).ToList();
            
            foreach (Contact contact in contacts)
            {
                ContactInfoDto newContact = new ContactInfoDto
                {
                    Name = contact.Name,
                    CompanyName = contact.Company.Name,
                    Country = contact.Country.Name
                };
                contactInfos.Add(newContact);
            }

            return contactInfos;
        }

        public List<ContactDto> FilterContact(int? countryId, int? companyId)
        {
            List<ContactDto> contactsDto = new List<ContactDto>();
            List<Contact> filteredContacts = new List<Contact>();
            try
            {

                if(companyId == null)
                {
                    filteredContacts = _contactRepository.GetAll().Where(x => x.CountryId.Equals(countryId)).ToList();
                } 
                else if(countryId == null)
                {
                    filteredContacts = _contactRepository.GetAll().Where(x => x.CompanyId.Equals(companyId)).ToList();
                } 
                else
                {
                    filteredContacts = _contactRepository.GetAll().Where(x => x.CountryId.Equals(countryId) && x.CompanyId.Equals(companyId)).ToList();
                }


            foreach (Contact item in filteredContacts)
            {
                contactsDto.Add(item.ToDto());
            }
            }
            catch(Exception ex)
            {
                throw new Exception("Please set a filter!");
            }

            return contactsDto;
        }

    }
}
