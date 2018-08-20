using System;
using System.Collections.Generic;

namespace Scrumptious.Data.Models
{
    public partial class Sprint : Library.Models.Sprint
    {
        public Sprint()
        {
            Backlog = new HashSet<Backlog>();
        }

        public int SprintId { get; set; }
    
        public bool Completed { get; set; }
        public int FkProjectId { get; set; }

        public Project FkProject { get; set; }
        public ICollection<Backlog> Backlog { get; set; }
    }
}
