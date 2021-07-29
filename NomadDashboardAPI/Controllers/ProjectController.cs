using Microsoft.AspNetCore.Mvc;
using NomadDashboardAPI.Interfaces;
using NomadDashboardAPI.ViewModels;

namespace NomadDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProject _projectService;

        public ProjectController(IProject projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("GetProjects")]
        public ActionResult GetProjects()
        {
            var projects = _projectService.GetAllProject();
            return Ok(projects);
        }

        [HttpPost]
        [Route("AddProject")]
        public ActionResult AddProjects(ProjectModel model)
        {
            _projectService.CreateProject(model);
            _projectService.SaveChanges();
            return Ok("created");
        }

    }
}