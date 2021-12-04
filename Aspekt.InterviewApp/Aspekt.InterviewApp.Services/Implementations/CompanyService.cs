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
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void CreateCompany(CompanyDto company)
        {
            _companyRepository.Create(company.ToDomain());
        }

        public List<CompanyDto> GetAllCompanies()
        {
           List<Company> companies = _companyRepository.GetAll();

            List<CompanyDto> companyDtos = new List<CompanyDto>();

            foreach (Company item in companies)
            {
                companyDtos.Add(item.ToDto());
            }

            return companyDtos;
        }

        public void UpdateCompany(CompanyDto company)
        {
            _companyRepository.Update(company.ToDomain());
        }

        public void DeleteCompany(int companyId)
        {
            _companyRepository.Delete(companyId);
        }
    }
}
