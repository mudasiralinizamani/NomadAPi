using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.ViewModels
{
    public class ProjectModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }

        public string Status { get; set; }

        public string Rate { get; set; }

        public int Progress { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string DeadLine { get; set; }
    }

}

