using Aspekt.InterviewApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspekt.InterviewApp.Domain
{
    public class AspektDbContext : DbContext
    {
            public AspektDbContext(DbContextOptions options) : base(options) { }

            public DbSet<Company> Companies { get; set; }
            public DbSet<Country> Countries { get; set; }
            public DbSet<Contact> Contacts { get; set; }

    }
}
