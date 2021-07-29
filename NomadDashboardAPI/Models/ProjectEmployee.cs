using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Models
{
    public class ProjectEmployee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string EmployeeId { get; set; }

        public string EmployeeUserName { get; set; }

        public string ProjectId { get; set; }

    }
}
