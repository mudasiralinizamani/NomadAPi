using Microsoft.EntityFrameworkCore;
using NomadDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Contexts
{
    public class APIContext : DbContext
    {
        public APIContext()
        {

        }

        public DbSet<Lead> Leads { get; set; }
    }
}
