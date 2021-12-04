﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspekt.InterviewApp.Domain.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
