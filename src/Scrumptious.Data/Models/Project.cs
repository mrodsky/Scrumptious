using System;
using System.Collections.Generic;

namespace Scrumptious.Data.Models
{
    public partial class Project
    {
        public Project()
        {
            Sprint = new HashSet<Sprint>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectRequirements { get; set; }
        public string ProjectDescription { get; set; }
        public bool Active { get; set; }

        public ICollection<Sprint> Sprint { get; set; }
    }
}
