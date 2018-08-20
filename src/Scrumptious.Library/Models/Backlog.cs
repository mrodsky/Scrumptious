using System;
using System.Collections.Generic;

namespace Scrumptious.Library.Models
{
    public class Backlog 
    {
        public Backlog()
        {
            Task = new List<Task>();
        }

        public List<Task> Task { get; set; }
    }
}
