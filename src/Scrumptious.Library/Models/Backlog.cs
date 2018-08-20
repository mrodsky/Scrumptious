using System;
using System.Collections.Generic;

namespace Scrumptious.Library.Models
{
    public class Backlog 
    {
        public Backlog()
        {
            Task = new HashSet<Task>();
        }

        public ICollection<Task> Task { get; set; }
    }
}
