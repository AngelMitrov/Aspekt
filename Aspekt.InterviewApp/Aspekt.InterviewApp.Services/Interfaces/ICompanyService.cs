using Aspekt.InterviewApp.DTOs.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspekt.InterviewApp.Services.Interfaces
{
    public interface ICompanyService
    {
        void CreateCompany(CompanyDto company);
        List<CompanyDto> GetAllCompanies();
        void UpdateCompany(CompanyDto company);
        void DeleteCompany(int companyId);
    }
}
