using NomadDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Interfaces
{
    public interface ILead
    {
        IEnumerable<Lead> GetAllLeads();

        Lead GetLeadById();
    }
}
