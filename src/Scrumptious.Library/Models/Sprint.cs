using System;
using System.Collections.Generic;

namespace Scrumptious.Library.Models
{
    public partial class Sprint
    {
        public Sprint()
        {
            Backlog = new HashSet<Backlog>();
        }

     
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SprintDescription { get; set; }
    

    
        public ICollection<Backlog> Backlog { get; set; }
    }
}
