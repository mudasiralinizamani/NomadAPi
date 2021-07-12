using Microsoft.AspNetCore.Mvc;
using NomadDashboardAPI.Interfaces;
using NomadDashboardAPI.Models;
using System.Collections.Generic;

namespace NomadDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILead _leadService;

        public LeadController(ILead leadService)
        {
            _leadService = leadService;
        }

        // Route = /api/Lead/GetAllLeads/
        [HttpGet]
        [Route("GetAllLeads")]
        public ActionResult<IEnumerable<Lead>> GetAllLeads()
        {
            var leads = _leadService.GetAllLeads();
            return Ok(leads);
        }

        [HttpGet]
        [Route("GetLeadById/{id}")]
        public ActionResult<Lead> GetLeadById(string id)
        {
            var leads = _leadService.GetLeadById(id);
            if (leads != null)
            {
                return Ok(new { succeeded = true, leads = leads });
            }
            else
            {
                return Ok(new { succeeded = false, code = "LeadNotFound", description = "Lead with id '" + id + "' Not Found" });
            }
        }
    }
}