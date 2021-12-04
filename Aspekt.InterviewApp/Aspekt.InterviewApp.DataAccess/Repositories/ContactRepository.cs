using Aspekt.InterviewApp.DataAccess.Interfaces;
using Aspekt.InterviewApp.Domain;
using Aspekt.InterviewApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspekt.InterviewApp.DataAccess.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private AspektDbContext _aspektDbContext;

        public ContactRepository(AspektDbContext aspektDbContext)
        {
            _aspektDbContext = aspektDbContext;
        }

        public int Create(Contact entity)
        {
            Company company = _aspektDbContext.Companies.FirstOrDefault(x => x.Id.Equals(entity.CompanyId));
            Country country = _aspektDbContext.Countries.FirstOrDefault(x => x.Id.Equals(entity.CountryId));

            if(company == null)
                throw new Exception("You are sending invalid company to the object!");
            
            if(country == null)
                throw new Exception("You are sending invalid country to the object!");

            if (entity.Id != 0)
                throw new Exception("Country ID is automatically incremented, please set it to zero!");

            _aspektDbContext.Contacts.Add(entity);
                _aspektDbContext.SaveChanges();

            return entity.Id;
        }

        public List<Contact> GetAll()
        {
            List<Contact> contacts = _aspektDbContext
                .Contacts
                .Include(x => x.Company)
                .Include(x => x.Country)
                .ToList();

            if (contacts.Count().Equals(0))
            {
                throw new Exception($"You dont have any contacts!");
            }

            return contacts;
        }

        public void Update(Contact entity)
        {
            try
            {
                _aspektDbContext.Update(entity);
                _aspektDbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("You cannot update a contact that does not exist!");
            }
        }
        public void Delete(int id)
        {
            Contact contact = _aspektDbContext.Contacts.FirstOrDefault(x => x.Id.Equals(id));

            if (contact == null)
                throw new Exception($"Contact with ID: {id} not found!");


            _aspektDbContext.Contacts.Remove(contact);
            _aspektDbContext.SaveChanges();
        }
    }
}
