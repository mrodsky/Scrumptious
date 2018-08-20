using System;
using System.Collections.Generic;

namespace Scrumptious.Library.Models
{
    public partial class Project
    {
        public Project()
        {
            Sprint = new HashSet<Sprint>();
        }

        
        public string ProjectName { get; set; }
        public string ProjectRequirements { get; set; }
        public string ProjectDescription { get; set; }
     

        public ICollection<Sprint> Sprint { get; set; }
    }
}
