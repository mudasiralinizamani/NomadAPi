using NomadDashboardAPI.Interfaces;
using NomadDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Services
{
    public class ILeadService : ILead
    {
        public IEnumerable<Lead> GetAllLeads()
        {
            throw new NotImplementedException();
        }

        public Lead GetLeadById()
        {
            throw new NotImplementedException();
        }
    }
}
