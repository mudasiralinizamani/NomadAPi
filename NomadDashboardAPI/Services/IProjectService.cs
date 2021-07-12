using NomadDashboardAPI.Interfaces;
using NomadDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Services
{
    public class IProjectService : IProject
    {
        public IEnumerable<Project> GetAllProject()
        {
            throw new NotImplementedException();
        }

        public Project GetProjectById()
        {
            throw new NotImplementedException();
        }
    }
}
