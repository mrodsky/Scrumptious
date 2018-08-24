using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumptious.MvcClient.Models
{
    public class ProjectViewModel
    {
        public string projectName { get; set; }
        public int projectId { get; set; }
        public string projectDescription { get; set; }
        public List<SprintViewModel> sprint { get; set; }
        public bool active { get; set; }
        public string projectRequirements { get; set; }
    }
}
