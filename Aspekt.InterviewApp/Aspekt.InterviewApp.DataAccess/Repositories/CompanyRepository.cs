using Aspekt.InterviewApp.DataAccess.Interfaces;
using Aspekt.InterviewApp.Domain;
using Aspekt.InterviewApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspekt.InterviewApp.DataAccess.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private AspektDbContext _aspektDbContext;

        public CompanyRepository(AspektDbContext aspektDbContext)
        {
            _aspektDbContext = aspektDbContext;
        }

        public int Create(Company entity)
        {
            if (entity.Id != 0)
            {
                throw new Exception("Company ID is automatically incremented, please set it to zero!");
            }
            _aspektDbContext.Companies.Add(entity);
            _aspektDbContext.SaveChanges();
            return entity.Id;
        }

        public List<Company> GetAll()
        {
            List<Company> companies = _aspektDbContext.Companies.ToList();
            if (companies.Count().Equals(0))
            {
                throw new Exception($"You dont have any companies!");
            }
            return companies;
        }

        public void Update(Company entity)
        {
            try
            {
                _aspektDbContext.Companies.Update(entity);
                _aspektDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("You cannot update a company that does not exist!");

            }
        }

        public void Delete(int id)
        {
            Company company = _aspektDbContext.Companies.FirstOrDefault(x => x.Id.Equals(id));
            if (company == null)
                throw new Exception($"Company with ID: {id} not found!");
            
            _aspektDbContext.Companies.Remove(company);
            _aspektDbContext.SaveChanges();
        }
    }
}
