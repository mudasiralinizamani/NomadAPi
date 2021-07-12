using NomadDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Interfaces
{
    interface IProject
    {
        IEnumerable<Project> GetAllProject();

        Project GetProjectById();

    }
}
