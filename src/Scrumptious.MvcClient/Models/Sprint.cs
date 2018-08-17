using System;
using System.Collections.Generic;

namespace Scrumptious.MvcClient.Models
{
    public partial class Sprint
    {
        public Sprint()
        {
            Backlog = new HashSet<Backlog>();
        }

        public int SprintId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SprintDescription { get; set; }
        public bool Completed { get; set; }
        public int FkProjectId { get; set; }

        public Project FkProject { get; set; }
        public ICollection<Backlog> Backlog { get; set; }
    }
}
