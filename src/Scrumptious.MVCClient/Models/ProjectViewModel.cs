using Scrumptious.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumptious.MVCClient.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {

        }
        public int ProjectId { get; set; }
        public bool Active { get; set; }
        public string ProjectName { get; set; }
        public string ProjectRequirements { get; set; }
        public string ProjectDescription { get; set; }

        public List<SprintViewModel> Sprint { get; set; }
    }
}
