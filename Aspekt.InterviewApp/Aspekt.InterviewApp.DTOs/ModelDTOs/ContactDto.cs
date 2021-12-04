using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspekt.InterviewApp.DTOs.ModelDTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
        public int CountryId { get; set; }
        public CountryDto Country { get; set; }
    }
}
