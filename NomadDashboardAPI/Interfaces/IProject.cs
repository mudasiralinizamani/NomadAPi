using NomadDashboardAPI.Models;
using NomadDashboardAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Interfaces
{
    public interface IProject
    {
        IEnumerable<Project> GetAllProject();

        Project GetProjectById(string id);

        IEnumerable<Project> GetInProgressProjects();

        IEnumerable<Project> GetNotStartedProjects();

        IEnumerable<Project> GetOnHoldProjects();

        IEnumerable<Project> GetCancelledProjects();

        IEnumerable<Project> GetFinishedProjects();


        bool SaveChanges();


        void CreateProject(ProjectModel model);

        void DeleteProjcet(Project model);

    }
}
