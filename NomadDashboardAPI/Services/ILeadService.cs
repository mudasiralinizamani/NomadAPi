using NomadDashboardAPI.Contexts;
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
        private readonly APIContext _apiContext;

        public ILeadService(APIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public IEnumerable<Lead> GetAllLeads()
        {
            IEnumerable<Lead> leads = _apiContext.Leads.ToList();
            return leads;
        }

        public Lead GetLeadById(string id)
        {
            Lead lead = _apiContext.Leads.FirstOrDefault(l => l.Id == id);
            return lead;
        }
    }
}
